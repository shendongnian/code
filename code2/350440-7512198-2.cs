        public XmlElement CallWs(ServiceEndpoint endpoint, String operation, XmlElement request)
        {
            String soapAction = GetSoapAction(endpoint, operation);
            IChannelFactory<IRequestSessionChannel> factory = null;
            try
            {
                factory = endpoint.Binding.BuildChannelFactory<IRequestSessionChannel>();
                factory.Open();
                IRequestSessionChannel channel = null;
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
