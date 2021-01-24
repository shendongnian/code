    string pass = "abc"; // guessing types and values
    string fail = "failed";
    string sqliteCon = "Data Source=(localdb)\\MSSQLLocalDB;Database=BooksDb";
    using (SqlConnection connection = new SqlConnection(sqliteCon))
    {
        connection.Open();
        var queryString = @"SELECT ResItem AS RD 
                    FROM tabStoreExec 
                    JOIN tabList ON tabStoreExec.idSE = tabList.idL 
                    WHERE tabList.Selection=1";
        var values = new List<string>();
        using (SqlCommand command = new SqlCommand(queryString, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    values.Add(reader[0].ToString());
                }
            }
        }
        var queryInsert = @"INSERT INTO tabStoricoDetail (NomeItem,ResItemDet,DateStartDet,DateEndDet) 
                                    VALUES (@NI, @RProva, @DATESE, @DATEED)";
        using (SqlCommand command2 = new SqlCommand(queryInsert, connection))
        {
            foreach(var value in values)
            {
                if (value.Equals(pass))
                {
                    command2.Parameters.AddWithValue("@RProva", value);
                }
                else
                {
                    command2.Parameters.AddWithValue("@RProva", fail);
                }
                command2.ExecuteNonQuery();
            }
        }
    }
