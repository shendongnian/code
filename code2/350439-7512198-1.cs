        public void CallWs()
        {
            WsdlRDListProductsPortTypeClient client = new WsdlRDListProductsPortTypeClient();
            String req = "<Root xmlns=\"urn:ns\"><Query><Group>TV</Group><Product>TV</Product></Query></Root>";
            CallWs(client.Endpoint, "ListProducts", GetRequestXml(req));
        }
        public XmlElement CallWs(ServiceEndpoint endpoint, String operation, XmlElement request)
        {
            String soapAction = GetSoapAction(endpoint, operation);
            IChannelFactory<IRequestChannel> factory = null;
            try
            {
                factory = endpoint.Binding.BuildChannelFactory<IRequestChannel>();
                factory.Open();
                IRequestChannel channel = null;
                try
                {
                    channel = factory.CreateChannel(endpoint.Address);
                    channel.Open();
                    Message requestMsg = Message.CreateMessage(endpoint.Binding.MessageVersion, soapAction, request);
                    Message response = channel.Request(requestMsg);
                    return response.GetBody<XmlElement>();
                }
                finally
                {
                    if (channel != null)
                        channel.Close();
                }
            }
            finally
            {
                if (factory != null)
                    factory.Close();
            }
        }
        private String GetSoapAction(ServiceEndpoint endpoint, String operation)
        {
           
            foreach (OperationDescription opD in endpoint.Contract.Operations)
            {
                if (opD.Name == operation)
                {
                    foreach (MessageDescription msgD in opD.Messages)
                        if (msgD.Direction == MessageDirection.Input)
                        {
                            return msgD.Action;
                        }
                }
            }
            return null;
        }
