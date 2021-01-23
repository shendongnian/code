    int totalRecordsToWrite = 100000;
    int maxRecordsPerCommand = 500;
    SqlConnection sqlc = new SqlConnection(
                            "Data Source=" + Environment.MachineName + @"\SQLEXPRESS;" +
                            "Integrated security=true;" +
                            "database=someDB");
    
    int currentRecord = 0;
    
    while (currentRecord < totalRecordsToWrite)
    {
        SqlCommand sqlcmd;
        string tmp = string.Empty;
        for(int j = 0; j < maxRecordsPerCommand; j++)
        {
            currentRecord++;
            
            if (currentRecord >= totalRecordsToWrite)
              break;
            
            // Insert record "currentRecord" of the 100000 here.
            
            tmp += "inserto into [db].[Files](...) values (...);"
        }
        using (sqlcmd = new SqlCommand(tmp, sqlc))
        {
           try { sqlc.Open(); sqlcmd.ExecuteNonQuety(); } catch{}
        }
    }
