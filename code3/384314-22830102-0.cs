        /*table code
         * create table login
               (
                    id varchar(25),
                        pass varchar(25)
                )   
         * 
         * 
         * 
         * 
         */
        string Connectstring = @"Data Source=DELL-PC;Initial Catalog=stud;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(Connectstring);
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from log where id=@a and pass=@b", cn);
            cmd.Parameters.AddWithValue("@a", textBox1.Text.ToString().ToUpper());
            cmd.Parameters.AddWithValue("@b", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if ((dr.Read() == true))
            {
                MessageBox.Show("The user is valid!");
                Form2 mainForm = new Form2();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }
