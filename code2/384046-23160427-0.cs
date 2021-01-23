    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace access_db_csharp
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       public SqlConnection con = new SqlConnection(@"Place Your connection string");
                
               private void Savebutton_Click(object sender, EventArgs e)
        {
             SqlCommand cmd = new SqlCommand("insert into  Data (Name,PhoneNo,Address) values(@parameter1,@parameter2,@parameter3)",con);
                    cmd.Parameters.AddWithValue("@parameter1", (textBox1.Text));
                    cmd.Parameters.AddWithValue("@parameter2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@parameter3", (textBox4.Text));
                    cmd.ExecuteNonQuery();
                    }
        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = connectionstring;
            con.Open();
        }
    }
