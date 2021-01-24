    using (ServiceHost sh = new ServiceHost(typeof(MyService)))
                {
                    sh.Open();
                    Console.WriteLine("serivce is ready....");
                    Console.ReadLine();
                    sh.Close();
                }
