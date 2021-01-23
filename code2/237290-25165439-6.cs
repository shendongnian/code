    using System;
    using System.ServiceModel;
    using System.Threading;
    
    namespace TestClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                IClientService proxy = null;
    
                try
                {
                    proxy = ChannelFactory<IClientService>.CreateChannel(new BasicHttpBinding(), new EndpointAddress("http://localhost:8010/ClientService"));
                    Console.WriteLine("Press <Enter> when ClientService is running.");
                    Console.ReadLine();
                    Console.WriteLine();
    
                    Console.WriteLine("Sending a single message to ClientService");
                    proxy.ClientNotification("Hello from TestClient");
    
                    Console.WriteLine();
    
                    Console.Write("Enter a valid number to load test ClientService: ");
                    string result = Console.ReadLine();
                    int testCount = Convert.ToInt32(result);
                    int counter = 0;
                    object counterLock = new object();
    
                    while (true)
                    {
                        lock (counterLock)
                        {
                            Thread t = new Thread(() => proxy.ClientNotification(string.Format("Load test from TestClient: {0}", ++counter)));
                            t.Start();
                        }
    
                        if (counter == testCount)
                            break;
                    }
    
                    Console.ReadLine();
                }
                finally
                {
                    ICommunicationObject co = proxy as ICommunicationObject;
                    try
                    {
                        co.Close();
                    }
                    catch { co.Abort(); }
                }
    
                Console.ReadLine();
            }
        }
    }
