    EntityConnectionStringBuilder entityConnectionBuilder = new 
    EntityConnectionStringBuilder();
    entityConnectionBuilder.Metadata = 
    "res://*/PresentModel.csdl|res://*/PresentModel.ssdl|res://*/PresentModel.msl";
    entityConnectionBuilder.Provider = "System.Data.SqlClient";
    entityConnectionBuilder.ProviderConnectionString = 
    connectionStringBuilder.ConnectionString;
