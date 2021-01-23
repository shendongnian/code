    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new UnityContainer())
            {
                container
                    .AddExtension(new ConfigureForConsole(args))
                    .Resolve<MyApplication>()
                    .Execute();
            }
        }
    }
