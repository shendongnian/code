    public bool CheckConnection()
    {
        string connectionString = ""; //Get from configuraiton.
        using(var conn = new OracleConnection(connectionString))
        {
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
