    public static void UseConnector(Action<DataAccess> action)
    {
        lock (_syncObject)
        {
            action(_connector);
        }
    }
