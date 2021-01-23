    private static Dictionary<Type, string> _tableNames = new Dictionary<Type, string>
    {
        {typeof(Sequence), "Sequences"},
        {typeof(Account), "Accounts"},
        {typeof(Test), "Tests"}
    }
    public static IAzureTable<T> GetTable(string datastorevalue) where T: Microsoft.WindowsAzureStorageClient.TableServiceEntity
    {
        return new AzureTable<T>(GetStorageAccount(datastoreValue), _tableNames[typeof(T)]);
    }
