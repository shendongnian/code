            bool bolIsInsert = (sSQLUpper.Contains("OUTPUT INSERTED."));
            try
            {
                if (bolIsInsert)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    InsertedID = (int)cmd.ExecuteScalar();
                } else
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Error = e.Message.ToString();
            }
