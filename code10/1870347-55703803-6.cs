    string pass = "abc"; // guessing types and values
    string fail = "failed";
    string sqliteCon = "Data Source=(localdb)\\MSSQLLocalDB;Database=BooksDb";
    using (SqlConnection connection = new SqlConnection(sqliteCon))
    {
        connection.Open();
        var queryString = @"SELECT ResItem AS RD 
                    FROM tSE 
                    JOIN tL ON tSE.idSE = tL.idL 
                    WHERE tL.Selection=1";
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
        var queryInsert = @"INSERT INTO tSD (NomeItem,ResItemDet,DateStartDet,DateEndDet) 
                                    VALUES (@NI, @RProva, @DATESE, @DATEED)";
        using (SqlCommand command2 = new SqlCommand(queryInsert, connection))
        {
            foreach(var value in values)
            {
                command2.Parameters.Clear();
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
