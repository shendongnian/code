    namespace DemoIoC
    {
        using System;
        using StructureMap;
        public static class Program
        {
            public static void Main(string[] args)
            {
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
