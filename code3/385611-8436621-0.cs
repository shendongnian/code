    //Build the connection 
    SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder();
    
    //Put your server or server\instance name here.  Likely YourComputerName\SQLExpress
    bldr.DataSource = ".\\SQLEXPRESS";
    
    //Attach DB Filename
    bldr.AttachDBFilename = bldr.AttachDBFilename = @"C:\Documents and Settings\1091912\My Documents\Visual Studio 2010\WebSites\BrokerBuy\App_Data\BrokerBuy.mdf";
    
    //User Instance
    bldr.UserInstance = true;
    
    //Whether or not a password is required.
    bldr.IntegratedSecurity = true;
    
    SqlConnection connectionString = new SqlConnection(bldr.ConnectionString);
    connectionString.Open();
