      public class AuthenticationBehaviour : IEndpointBehavior
    {
        #region IEndpointBehavior Members
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            //AuthenticationMessageInspector inspector = new AuthenticationMessageInspector();
            //clientRuntime.MessageInspectors.Add(inspector);
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            AuthenticationMessageInspector inspector = new AuthenticationMessageInspector();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
            //Console.WriteLine("Dispatcher Applied!");
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
        #endregion
    }
       public class AuthenticationMessageInspector : IDispatchMessageInspector
    {
       
        #region Members
        private string conStr = "", commStr = "";
        public IDbConnection Connection { get; set; }
        public IDbCommand Command { get; set; }
        public IDataReader Reader { get; set; }
        #endregion        
        private const string HeaderKey = "Authentication";
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //Console.WriteLine("recieved Request! ");
            int headerIndex = request.Headers.FindHeader(HeaderKey, string.Empty);
            if (headerIndex < 0 || string.IsNullOrEmpty(request.Headers.GetHeader<String>(headerIndex)))
            {
               
                throw (new Exception("Access Denied!\n"));
                return null;
            } 
           
            bool valid = Validate(request.Headers.GetHeader<String>(headerIndex));
            if (!valid)
            {
                Console.WriteLine("recieved Request! From " + request.Headers.GetHeader<String>(headerIndex) + " and Access Denied!\n");
                throw (new Exception("Access Denied!\n" + request.Headers.GetHeader<String>(headerIndex) + " License Number is not athourized! "));         
            }
            if (headerIndex != -1)
            {
                Console.WriteLine("recieved Request! From " + request.Headers.GetHeader<String>(headerIndex));
            }
            return null;
            
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
           
        }
    }
