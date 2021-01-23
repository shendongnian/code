    using (var connection = new SqlConnection(connString))
        using (var command = connection.CreateCommand()) {
            string tsql = @"
                select *
                    from Talent
                    where DATEDIFF(YEAR, BirthDay, GETDATE()) BETWEEN @minAge AND @maxAge";
            
            command.CommandText = tsql;
            command.CommandType = CommandType.Text;
            
            int minAge = 1;
            int maxAge = 120;
            SqlParameter minAgeParam = command.CreateParameter();
            minAgeParam.Direction = ParameterDirection.Input;
            minAgeParam.DbType = SqlDbType.TinyInt;
            minAgeParam.ParameterName = "@minAge";
            minAgeParam.Value = minAge;
            SqlParameter maxAgeParam = command.CreateParameter();
            maxAgeParam.Direction = ParameterDirection.Input;
            maxAgeParam.DbType = SqlDbType.TinyInt;
            maxAgeParam.ParameterName = "@maxAge";
            maxAgeParam.Value = maxAge;
            // Just unsure here whether I must add the parameters to the command,
            // or if they are already part of it since I used the 
            // SqlCommand.CreateParameter() method. 
            // Been too long since I haven't done any ADO.NET
            command.Parameters.Add(minAgeParam);
            command.Parameters.Add(maxAgeParam);
            connection.Open();
            SqlDataReader reader = null;
            try {
                reader = command.ExecuteReader();
                // Process your records here...
            } finally {
                connection.Close()
                command.Dispose();
                connection.Dispose();
                if (reader != null) {
                    reader.Dispose();
                }
            }
        }
