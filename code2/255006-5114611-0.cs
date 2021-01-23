    public partial class Form1 : Form
        {
            SqlConnection conn = new SqlConnection("Data Source=TODO;Initial Catalog=TODO;Integrated Security=True");
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                using (SqlCommand command = new SqlCommand("sp_setapprole 'my_app' , 'app_pass' ", conn))
                {
                    command.CommandType = CommandType.Text;
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                // The application role is set and remains active until the user disconnects
    
                Form2 f2 = new Form2(conn);
                f2.Show();
            }
        }
    
        public partial class Form2 : Form
        {
            SqlConnection conn = null;
            //how to connect to the database, 
            public Form2(SqlConnection conn)
            {
                InitializeComponent();
                this.conn = conn;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("create database new_db", conn))
                    {
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    // Important to close the DB connection (at which point the approle becomes inactive)
                    conn.Close();
                }
    
            }
        }
