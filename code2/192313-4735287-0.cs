            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8));
            HttpsTransportBindingElement transport = new HttpsTransportBindingElement();
            transport.AuthenticationScheme = AuthenticationSchemes.Basic;
            //transport.ProxyAuthenticationScheme = AuthenticationSchemes.Basic;
            transport.Realm = "XISOAPApps";
            binding.Elements.Add(transport);
            var address = new EndpointAddress("https://foooo");
            ........ create client proxy class
   
            service.ClientCredentials.UserName.UserName = "<login>";
            service.ClientCredentials.UserName.Password = "<password>";
         
