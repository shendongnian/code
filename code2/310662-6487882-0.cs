            using (var con = new OleDbConnection())
            {
                con.Open();
                using (var cmd = new OleDbCommand("sqlquery", conn))
                {
                    try
                    {
                                 //do Stuff here
                    }
                    catch (OleDbException)
                    {
                        throw;
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open) con.Close();
                    }
                }
             }
