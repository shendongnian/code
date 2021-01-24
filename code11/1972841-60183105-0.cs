    Uri uri = new Uri("http://localhost:21011");
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.MessageEncoding = WSMessageEncoding.Mtom;
                binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
