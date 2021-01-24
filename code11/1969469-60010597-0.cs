               var connectionValue = _iconfiguration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
                SqlConnection connection1 = new SqlConnection(connectionValue);
                var sql = "SELECT * FROM dbo.Codes WHERE ResponseLimit = 1";
                var command = new SqlCommand(sql, connection1);
                connection1.Open();
                command.ExecuteReader();
Since it is not relevant for you(?).
And change:
