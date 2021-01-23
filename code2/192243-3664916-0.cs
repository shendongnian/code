    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConfigurationManager.AppSettings["foo"]);
            if (!args.Contains("run"))
            {
                AppDomainSetup setup = new AppDomainSetup();
                setup.ConfigurationFile = "foo.xml";
                AppDomain dmn = AppDomain.CreateDomain("Foo", null, setup);
                dmn.ExecuteAssembly(Assembly.GetEntryAssembly().CodeBase,
                   new string[] { "run" } /* crude exit condition */
                );
            }
        }
    }
