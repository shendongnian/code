            CustomBinding Binding = new CustomBinding(BINDING_NAME);
            EndpointAddress EndPoint = new EndpointAddress(WsEndpoint);
            // Trust all certificates
            ServicePointManager.ServerCertificateValidationCallback = ((Sender, certificate, chain, sslPolicyErrors) => true);
            _WsProxy = new MyDataSoapClient(Binding, EndPoint);
            _WsProxy.Endpoint.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
            _WsProxy.ChannelFactory.Credentials.UserName.UserName = "username";
            _WsProxy.ChannelFactory.Credentials.UserName.Password = "pwd";
