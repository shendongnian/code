    string myCs = System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    
    System.Data.SqlClient.SqlConnectionStringBuilder csb = new System.Data.SqlClient.SqlConnectionStringBuilder(myCs);
    csb.Password = EncDecHelper.Decrypt(csb.Password);
    myCs = csb.ToString();
