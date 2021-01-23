    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace DBDemo2
    {
        public partial class Form1 : Form
        {
            string connectionString = "Database=company;Uid=sa;Pwd=mypassword";
            System.Data.SqlClient.SqlConnection connection;
            System.Data.SqlClient.SqlCommand command;
    
            SqlParameter idparam = new SqlParameter("@eid", SqlDbType.Int, 0);
            SqlParameter nameparam = new SqlParameter("@name", SqlDbType.NChar, 20);
            SqlParameter addrparam = new SqlParameter("@addr", SqlDbType.NChar, 10);
    
            public Form1()
            {
                InitializeComponent();
    
                connection = new System.Data.SqlClient.SqlConnection(connectionString);
                connection.Open();
                command = new System.Data.SqlClient.SqlCommand(null, connection);
                command.CommandText = "insert into employee(ename, city) values(@name, @addr);select SCOPE_IDENTITY();";
                
                command.Parameters.Add(nameparam);
                command.Parameters.Add(addrparam);
                command.Prepare();
    
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
            }
    
            private void buttonSave_Click(object sender, EventArgs e)
            {
    
    
                try
                {
                    int id = Int32.Parse(textBoxID.Text);
                    String name = textBoxName.Text;
                    String address = textBoxAddress.Text;
    
                    command.Parameters[0].Value = name;
                    command.Parameters[1].Value = address;
    
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int nid = Convert.ToInt32(reader[0]);
                        MessageBox.Show("ID : " + nid);
                    }
                    /*int af = command.ExecuteNonQuery();
                    MessageBox.Show(command.Parameters["ID"].Value.ToString());
                    */
                }
                catch (NullReferenceException ne)
                {
                    MessageBox.Show("Error is : " + ne.StackTrace);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error is : " + ee.StackTrace);
                }
            }
    
            private void buttonSave_Leave(object sender, EventArgs e)
            {
    
            }
    
            private void Form1_Leave(object sender, EventArgs e)
            {
                connection.Close();
            }
        }
    }
