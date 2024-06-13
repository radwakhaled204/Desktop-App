using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace connect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=RADWA;Initial Catalog=ConDB;Integrated Security=True;Connect Timeout=60";

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into Table_1 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfuly..!");
            }
        }


        /* func to delete */

        private void button2_Click(object sender, EventArgs e)
        {
            string nameToDelete = textBox1.Text;


            SqlConnection con = new SqlConnection(conString);

            con.Open();

            if (con.State == ConnectionState.Open)
            {
                string deleteQuery = "DELETE FROM Table_1 WHERE name = @name";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@name", nameToDelete);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Deleted Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No data found to delete.");
                    }
                }
            }

        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);

                con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        string updateQuery = "UPDATE Table_1 SET NikName = @newNikName, Age = @newAge, Phone = @newPhone WHERE Name = @nameToUpdate";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@newNikName", textBox2.Text);
                            cmd.Parameters.AddWithValue("@newAge", int.Parse(textBox3.Text)); // Assuming age is an integer
                            cmd.Parameters.AddWithValue("@newPhone", textBox4.Text);
                            cmd.Parameters.AddWithValue("@nameToUpdate", textBox1.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record Updated Successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No records found to update.");
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        /*endf*/


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        /*no pranthese*/
    }
}