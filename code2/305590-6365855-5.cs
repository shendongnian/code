    namespace DemoIoC
    {
        using System;
        using StructureMap;
        public static class Program
        {
            public static void Main(string[] args)
            {
                // here you initialize structuremap from the config file.
                // You could probably use a FileSystemWatcher to reinitialize 
                // whenever the structuremap.config file changes
                ObjectFactory.Initialize(x =>
                {
                    x.UseDefaultStructureMapConfigFile = true;
                });
                var concrete = ObjectFactory.GetInstance<AbstractBase>();
                concrete.Method1();
                Console.ReadKey(true);
            }
        }
    }
