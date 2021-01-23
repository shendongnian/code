        EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
        if (serverName=="Local")
        {
            ecb.ProviderConnectionString = Properties.Settings.Default.ServerLocalConnectionString;
        }
        else
        {
            ecb.ProviderConnectionString = Properties.Settings.Default.ServerConnectionString;
        }
        ecb.Metadata = "res://*/";
        ecb.Provider = "System.Data.SqlClient";
        SomeEntities context = new SomeEntities(new EntityConnection(ecb.ToString());
