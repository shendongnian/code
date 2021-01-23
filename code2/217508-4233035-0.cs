    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    string connectionString = "Server=localhost;User ID=root;Password=****;Database=testing;Port=3306;Pooling=false";
    string insertQuery = "ALTER TABLE `user` ADD lol INT (15)";
    using(MySql.Data.MySqlClient.MySqlConnection connection =
        new MySql.Data.MySqlClient.MySqlConnection(connectionString))
    using(MySql.Data.MySqlClient.MySqlCommand myCommand =
        new MySql.Data.MySqlClient.MySqlCommand(insertQuery))
    {
        myCommand.Connection = connection;
        connection.Open();
        myCommand.ExecuteNonQuery();
        connection.Close();
    }
    using(Form1 form1 = new Form1()) {
        Application.Run(form1);
    }
