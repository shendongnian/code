    using (ServiceHost sh = new ServiceHost(typeof(MyService)))
                {
                    sh.Open();
                    Console.WriteLine("Service is ready....");
    
                    Console.ReadLine();
                    sh.Close();
                }
