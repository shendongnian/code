    Uri uri = new Uri("https://localhost:21011");
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.MessageEncoding = WSMessageEncoding.Mtom;
                binding.Security.Mode = BasicHttpSecurityMode.Transport;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
