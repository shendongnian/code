    string connection = "server=localhost;database=adil;user=root;password=";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            MySqlCommand command = new MySqlCommand();
           
            command.Connection = con;
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from studentrec";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, con);
            DataTable table = new DataTable();
            MyDA.Fill(table);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
