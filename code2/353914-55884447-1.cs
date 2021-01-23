    public static void Output<T>(IEnumerable<T> dataSource) where T : class
    {
        string dataSourceName = typeof(T).Name;
        switch (dataSourceName)
        {
            case nameof(CustomerDetails):
                var t = 123;
                break;
            default:
                Console.WriteLine("Test");
        }
    }
