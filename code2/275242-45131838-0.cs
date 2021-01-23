    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    namespace Library
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
    
            private void button1_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NIKHIL R\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "INSERT INTO [Table] (BookName , AuthorName , Category) VALUES('" + textBox1.Text.ToString() + "' , '" + textBox2.Text.ToString() + "' , '" + textBox3.Text.ToString() + "')";
                SqlCommand com = new SqlCommand(query, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Entry Added");
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NIKHIL R\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM [TABLE] WHERE BookName='" + textBox1.Text.ToString() + "' OR AuthorName='" + textBox2.Text.ToString() + "'";
                string query1 = "SELECT BookStatus FROM [Table] where BookName='" + textBox1.Text.ToString() + "'";
                string query2 = "SELECT DateOfReturn FROM [Table] where BookName='" + textBox1.Text.ToString() + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr, dr1,dr2;
                con.Open();
                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
    
                if (dr.Read())
                {
                    con.Close();
                    con.Open();
                    SqlCommand com1 = new SqlCommand(query1, con);
                    com1.ExecuteNonQuery();
                    dr1 = com1.ExecuteReader();
                    dr1.Read();
                    string i = dr1["BookStatus"].ToString();
                    if (i =="1" )
                    {
                        con.Close();
                        con.Open();
                        SqlCommand com2 = new SqlCommand(query2, con);
                        com2.ExecuteNonQuery();
                        dr2 = com2.ExecuteReader();
                        dr2.Read();
                       
    
                            MessageBox.Show("This book is already issued\n " + "Book will be available by "+ dr2["DateOfReturn"] );
    
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        dr = com.ExecuteReader();
                        dr.Read();
                       MessageBox.Show("BookFound\n" + "BookName=" + dr["BookName"] + "\n AuthorName=" + dr["AuthorName"]);
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("This Book is not available in the library");
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NIKHIL R\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM [TABLE] WHERE BookName='" + textBox1.Text.ToString() + "'";
                string dateofissue1 = DateTime.Today.ToString("dd-MM-yyyy");
                string dateofreturn = DateTime.Today.AddDays(15).ToString("dd-MM-yyyy");
                string query1 = "update [Table] set BookStatus=1,DateofIssue='"+ dateofissue1 +"',DateOfReturn='"+ dateofreturn +"' where BookName='" + textBox1.Text.ToString() + "'";
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr;
                com.ExecuteNonQuery();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    con.Open();
                    string dateofissue = DateTime.Today.ToString("dd-MM-yyyy");
                    textBox4.Text = dateofissue;
                    textBox5.Text = DateTime.Today.AddDays(15).ToString("dd-MM-yyyy");
                    SqlCommand com1 = new SqlCommand(query1, con);
                    com1.ExecuteNonQuery();
                    MessageBox.Show("Book Isuued");
                }
                else
                {
                    MessageBox.Show("Book Not Found");
                }
                con.Close();
    
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NIKHIL R\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");
                string query1 = "update [Table] set BookStatus=0 WHERE BookName='"+textBox1.Text.ToString()+"'";
                con.Open();
                SqlCommand com = new SqlCommand(query1, con);
                com.ExecuteNonQuery();
                string today = DateTime.Today.ToString("dd-MM-yyyy");
                DateTime today1 = DateTime.Parse(today);
                string query = "SELECT dateofReturn from [Table] where BookName='" + textBox1.Text.ToString() + "'";
                con.Close();
                con.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                dr.Read();
                string DOR = dr["DateOfReturn"].ToString();
                DateTime dor = DateTime.Parse(DOR);
                TimeSpan ts = today1.Subtract(dor);
                string query2 = "update [Table] set DateOfIssue=NULL, DateOfReturn=NULL WHERE BookName='" + textBox1.Text.ToString() + "'";
                con.Close();
                con.Open();
                SqlCommand com2 = new SqlCommand(query2, con);
                com2.ExecuteNonQuery();
                int x = int.Parse(ts.Days.ToString());
                if (x > 0)
                {
                    int fine = x * 5;
                    textBox6.Text = fine.ToString();
                    MessageBox.Show("Book Received\nFine=" + fine);
                }
                else
                {
                    textBox6.Text = "0";
                    MessageBox.Show("Book Received\nFine=0");
                }
                    con.Close();
            }
        }
    }
