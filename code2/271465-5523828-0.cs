            using (System.Data.Odbc.OdbcConnection connect = new System.Data.Odbc.OdbcConnection("Connection String"))
            {
                using (System.Data.Odbc.OdbcCommand command = connect.CreateCommand())
                {
                    string sql = "SELECT u.UserID, u.FirstName, u.SecondName, p.PicturePath FROM User u " +
                        "LEFT JOIN Pictures p ON p.UserID = u.UserID WHERE u.FirstName LIKE '%' + @search + '%' " +
                        "ORDER BY u.UserID DESC";
                    command.CommandText = sql;
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@search", searchValue);
                    using (System.Data.Odbc.OdbcDataReader dr = command.ExecuteReader())
                    {
                        //Do what you need here
                    }
                }
            }
