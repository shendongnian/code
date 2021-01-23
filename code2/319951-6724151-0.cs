    string queryString = "SELECT Minbuy, ordersTillsNow FROM items WHERE main = 1";
    using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            connection.Open();
    
            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MinBuy = int.Parse(reader[0].ToString());
                ordersTillsNow = int.Parse(reader[1].ToString());
                //Console.WriteLine(String.Format("{0}", reader[0]));
            }
        }
