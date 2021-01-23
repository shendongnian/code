        /*
            // This is just to illustrate how it can be implemented on an imperative declarared binding, channel and client.
            string url = "SOME WCF URL";
            BasicHttpBinding wsBinding = new BasicHttpBinding();                
            EndpointAddress endpointAddress = new EndpointAddress(url);
    
            ChannelFactory<ISomeService> channelFactory = new ChannelFactory<ISomeService>(wsBinding, endpointAddress);
            channelFactory.Endpoint.Behaviors.Add(new InspectorBehavior());
            ISomeService client = channelFactory.CreateChannel();
        */    
            public class InspectorBehavior : IEndpointBehavior
            {
                public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
                {
                    // No implementation necessary  
                }
        
                public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
                {
                    clientRuntime.MessageInspectors.Add(new MyMessageInspector());
                }
        
                public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
                {
                    // No implementation necessary  
                }
        
                public void Validate(ServiceEndpoint endpoint)
                {
                    // No implementation necessary  
                }  
        
            }
        
            public class MyMessageInspector : IClientMessageInspector
            {
                public object BeforeSendRequest(ref Message request, IClientChannel channel)
                {
                    // Do something with the SOAP request
                    string request = request.ToString();
                    return null;
                }
        
                public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
                {
                    // Do something with the SOAP reply
                    string replySoap = reply.ToString();
                }
            }
