    ServicePointManager.ServerCertificateValidationCallback += delegate
                {
                    return true;
                };
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, new EndpointAddress("https://10.157.13.69:11011"));
                factory.Credentials.UserName.UserName = "jack";
                factory.Credentials.UserName.Password = "123456";
                IService sv = factory.CreateChannel();
                try
                {
                    var result = sv.SayHello();
                    Console.WriteLine(result);
                }
                catch (Exception)
                {
    
                    throw;
                }
