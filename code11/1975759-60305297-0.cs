using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            {
                string ServerName = textBox1.Text;
                string Database = textBox2.Text;
                string Username = textBox3.Text;
                string Pass = textBox4.Text;
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source= " + ServerName + ";Initial Catalog= " + Database + ";User ID=" + Username + ";Password= " + Pass + ";";
                cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();
                    MessageBox.Show("Connection Open  !");
                    cnn.Close();
                }
                catch (Exception) { MessageBox.Show("Login Failed, Information is Incorrect"); }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string ServerName = textBox1.Text;
            string Database = textBox2.Text;
            string Username = textBox3.Text;
            string Pass = textBox4.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source= " + ServerName + ";Initial Catalog= " + Database + ";User ID=" + Username + ";Password= " + Pass + ";";
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "--your SQL query --";
            command.CommandType = CommandType.Text;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int CommunicatedRecordsCount = (int)reader[0];
                    textBox5.Text = CommunicatedRecordsCount.ToString();
                }
                reader.Close();
            }
            catch
            {
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
Where I was looking for a numerical output we changed the output slightly, but again thanks everyone for all the assistance.
