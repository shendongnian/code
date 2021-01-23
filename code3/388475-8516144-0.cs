    string CreateConnectionString(string server, string sampledb,  string userid, string password)
    {
       return string.Format("Server={0};Database={1};User ID={2};Password={3}Trusted_Connection=False;Encrypt=True;",server,sampledb,userid,password);
    
    }
