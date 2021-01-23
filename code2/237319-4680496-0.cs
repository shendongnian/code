     public static string getConnString(string database)
        {
            string connectionstring = "User Id=USER ID HERE;Password=PASSWORD HERE;Host=server;Database="+database+";Persist Security Info=True;Schema=public";
            EntityConnectionStringBuilder newconnstring = new EntityConnectionStringBuilder();
            newconnstring.Metadata = @"res://*/"; 
            newconnstring.Provider = "Devart.Data.PostgreSql";
            newconnstring.ProviderConnectionString = connectionstring;
            
            
            return newconnstring.ToString();
        }
