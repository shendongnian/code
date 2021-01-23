      public Boolean InsertMethod(Query _query)
        {
            var success = false;
            var queryString = string.Format(@"INSERT INTO TABLE(ID, OWNER, TEXT) VALUES (TABLE_SEQ.NEXTVAL,:OWNER, :TEXT)");
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    con.Open();
                    OracleCommand cmd = con.CreateCommand();
                    cmd.CommandText = queryString;
                    cmd.Parameters.Add("OWNER", _query.Owner);
                    cmd.Parameters.Add("TEXT", _query.Text);          
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated > 0) success = true;
                }
                return success;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }
