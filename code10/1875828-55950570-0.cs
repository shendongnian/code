      using System;
        
        public class Example
        {
            public static void Main()
            {
                var os = Environment.OSVersion;
                Console.WriteLine("Current OS Information:\n");
                Console.WriteLine("Platform: {0:G}", os.Platform);
                Console.WriteLine("Version String: {0}", os.VersionString);
                Console.WriteLine("Version Information:");
                Console.WriteLine("   Major: {0}", os.Version.Major);
                Console.WriteLine("   Minor: {0}", os.Version.Minor);
                Console.WriteLine("Service Pack: '{0}'", os.ServicePack);
                Console.ReadKey();
            }
        }
