    try
            {
                con.Open();
                try
                {
                    //Execute Queries 
                    // ....
                }
                catch
                {
                    // command related or  other  exception
                }
                finally
                {
                    con.Close();
                }
            } 
            catch
            {
                // connection error
            }
