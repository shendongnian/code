    var factory = new ChannelFactory<T>(myBinding, new EndpointAddress(address));
                //for HttpClientCredentialType.Basic
                factory.Credentials.UserName.UserName = "administrator";
                factory.Credentials.UserName.Password = "abcd1234!";
                //for window credentials
                //factory.Credentials.Windows.ClientCredential.UserName = "adminsitrator";
                //factory.Credentials.Windows.ClientCredential.Password = "abcd1234!";
                var channel = factory.CreateChannel();
