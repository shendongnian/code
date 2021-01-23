        SQLConnection conn;
        try
        {
            conn = new SQLConnection(String.Format("Server={0};AttachDbFilename={1};Database=dbname; Trusted_Connection=Yes;", "Server Address", @"Path To Database"));
            conn.Open();
            conn.Close();
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            conn.Dispose();
        }
