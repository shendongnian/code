        //create a MySQL connection with a query string
        MySqlConnection connection = new MySqlConnection("server=localhost;database=cs;uid=root;password=abcdaaa");
        //open the connection
        connection.Open();
        //close the connection
        connection.Close();
