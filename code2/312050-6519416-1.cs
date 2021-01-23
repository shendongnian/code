    private void SetupConnection()
    {
        conn.ConnectionString = 
            ConfigurationManager.ConnectionStrings["ZenLive"].ConnectionString;
    
        bool success = false;
    
        while(!success)
        {
            try
            {
                OdbcDataAdapter da = 
                   new OdbcDataAdapter("SELECT * FROM MTD_FIGURE_VIEW1 '", conn);
    
                da.Fill(ds);
                success = true;
            }
            catch(Exception e)
            {
                Log(e);
                Thread.Sleep(_retryPeriod)
            }
        }
    }
