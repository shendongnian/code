    public static void Main(string[] args)
        {
            ...
            var typeName = typeof(Worker);
            AppDomain ad = AppDomain.CreateDomain("New domain");
            Worker remoteWokrer = (Worker)ad.CreateInstanceAndUnwrap(typeof(Worker).Assembly.FullName, typeName.FullName);
            ...
        }
