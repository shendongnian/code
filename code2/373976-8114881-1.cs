        using System;
        using System.Data.Services;
        using DataModel;
        namespace MyDataServiceHost
        {
            public class MyDataServiceHost
            {
                public static void LaunchDataService(string baseAddress)
                {
                    Uri[] baseAddresses = new Uri[1];
                    baseAddresses[0] = new Uri(baseAddress);
                    using(DataServiceHost host = new DataServiceHost(typeof(YourDataService), baseAddresses))
                    {
                        host.Open();
                        Console.WriteLine("DataService up and running.....");
                        
                        Console.ReadLine();
                        host.Close();
                    }
                }
            }
        }
