            //Create binding
            //Note, this is not secure but it's not up to us to decide. This should only ever be run within
            //the VPN or Intranet where IPSec is active. If SAP is ever directly from outside the network,
            //credentials and messages will not be private.
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            //Assign address
            var address = new EndpointAddress(Host);
            //Create service client
            var client = new SAP_RFC_READ_TABLE.RFC_READ_TABLEPortTypeClient(binding, address);
            //Assign credentials
            client.ClientCredentials.UserName.UserName = User;
            client.ClientCredentials.UserName.Password = Password;
