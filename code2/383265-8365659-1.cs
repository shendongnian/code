       using (SqlConnection connection = new SqlConnection(
                   strConectionString))
        {
            SqlCommand command = new SqlCommand(StrSql, connection);
             command.Parameters.Add("@GuidID", SqlDbType.VarChar).Value = guid;
            command.Connection.Open();
            memberId = (int)command.ExecuteScalar();
        }
