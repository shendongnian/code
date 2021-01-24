       Uri uri = new Uri("http://10.157.13.69:16666");
                BasicHttpBinding binding = new BasicHttpBinding();
           ChannelFactory<ICalculator> factory = new ChannelFactory<ICalculator>(binding,new EndpointAddress(uri));
                ICalculator service = factory.CreateChannel();
                try
                {
                    var result = service.Add(34.32, 2.34);
                    Console.WriteLine(result);
        
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
            }
        
        [ServiceContract]
        public interface ICalculator
        {
            [OperationContract]
            double Add(double a, double b);
        }
