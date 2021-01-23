    public int Load()
        {
            string connectionString = "datasource=STUFF YOU SHOULDNT SEEdatabase=users";
            MySqlConnection mysql = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            mysql.SelectCommand = new MySqlCommand("SELECT * FROM [RegularUsers] WHERE Username = '" + this.username + "' AND Pass = '" + this.password + "'", conn);
            mysql.Fill(dataset);
            if (dataset.HasRows)
                return 1;
            return 0;
        }
