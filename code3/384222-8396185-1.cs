    public void InsertAccountData(string Usrname, string passwd)
    {
    
        string qry = string.format("INSERT INTO Account(Username, password) VALUES('{0}','{1}')", Usrname, password);
       using (SqlConnection connection = new SqlConnection(connectionString))
       {
        SqlCommand command = new SqlCommand(qry, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}",
                    reader[0], reader[1]));
            }
        }
    }
