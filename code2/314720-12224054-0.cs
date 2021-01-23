    using System.Data.EntityClient;
    
    public static string GetConnectionString(ObjectContext context)
    {
        return ((EntityConnection)context.Connection).StoreConnection.ConnectionString;
    }
