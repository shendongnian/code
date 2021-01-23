      using (var connection = new SqlConnection(strConectionString))
           using (var command = new SqlCommand(StrSql, connection))
           {
               command.Parameters.Add("@GuidID", SqlDbType.VarChar).Value = guid; 
               memberId = (int)command.ExecuteScalar();
           }
