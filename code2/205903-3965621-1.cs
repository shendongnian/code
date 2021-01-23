    SqlConnection sqlc = new SqlConnection(
                            "Data Source=" + Environment.MachineName + @"\SQLEXPRESS;" +
                            "Integrated security=true;" +
                            "database=someDB");
    for (int i = 0; i < 200; i++)
    {
        SqlCommand sqlcmd;
        string tmp = string.Empty;
        for(int j = 0; j < 500; j++)
        {
            int currentRecord = (i * 500) + j;
            
            // Insert record "currentRecord" of the 100000 here.
            
            tmp += "inserto into [db].[Files](...) values (...);"
        }
        using (sqlcmd = new SqlCommand(tmp, sqlc))
        {
           try { sqlc.Open(); sqlcmd.ExecuteNonQuety(); } catch{}
        }
    }
