       public class TextMessageProxy : ClientBase<IFredContract>, IFredContract
        {
            public TextMessageProxy(string url, WebHttpSecurityMode securityMode = WebHttpSecurityMode.None)
                : base(ConstructEndpoint(url, securityMode))
            {
            }
    
            public string SendTextMessage(string sendToPhoneNumber, string messageText)
            {
                return base.Channel.SendTextMessage(sendToPhoneNumber, messageText);
            }
    
            // This method constructs a WebHttpBinding endpoint with all the appropriate
            // settings for talking to our services.
            private static ServiceEndpoint ConstructEndpoint(string serviceUri, WebHttpSecurityMode securityMode)
            {
                var contract = ContractDescription.GetContract(typeof(IFredContract));
                var binding = new WebHttpBinding(securityMode);
    
                var address = new EndpointAddress(serviceUri);
                var endpoint = new ServiceEndpoint(
                    contract,
                    binding,
                    address);
    
                //custom stuff.  You may or may not need these settings, but I do.. 
                //I would think you need at least the behavior, as it is likely required, as it is in the web.config.
                //-------------
                var webHttpBehavior = new WebHttpBehavior()
                {
                    FaultExceptionEnabled = true
                };
    
                endpoint.Behaviors.Add(webHttpBehavior);
                //-------------
    
                return endpoint;
            }
        }
