      [Serializable()]
      public class ConsoleMessageTracer : BehaviorExtensionElement, 
      IClientMessageInspector ,IEndpointBehavior, System.Configuration.IConfigurationSectionHandler
      {
    
        private string _userName = string.Empty;
        private string _password = string.Empty;
    
        [XmlAttribute()]
        public string UserName
        {
          get { return _userName; }
          set { _userName = value; }
        }
    
        [XmlAttribute()]
        public string Password
        {
          get { return _password; }
          set { _password = value; }
        }
    
    
        private Message TraceMessage(MessageBuffer buffer)
        {
          Message msg = buffer.CreateMessage();
          Console.WriteLine("\n{0}\n", msg);
          return buffer.CreateMessage();
        }
    
    
        public void AfterReceiveReply(ref Message reply, object
            correlationState)
        {
          reply = TraceMessage(reply.CreateBufferedCopy(int.MaxValue));
        }
    
        public object BeforeSendRequest(ref Message request,
            IClientChannel channel)
        {
    
          request.Headers.Add(MessageHeader.CreateHeader("Security",
            "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd",
            tt, true, "http://www.isban.es/soap/actor/wssecurityUserPass")
            );
    
          return null;
        }
    
        public override Type BehaviorType
        {
          get { return this.GetType(); }
        }
    
        protected override object CreateBehavior()
        {
          return this;
        }
    
        #region IEndpointBehavior Members
    
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
          return;
        }
    
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
          clientRuntime.MessageInspectors.Add(new ConsoleMessageTracer());
          //foreach (ClientOperation op in clientRuntime.Operations)
          //  op.ParameterInspectors.Add(new ConsoleMessageTracer());
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
          //endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new ConsoleMessageTracer());
          //foreach (DispatchOperation op in endpointDispatcher.DispatchRuntime.Operations)
          //  op.ParameterInspectors.Add(new ConsoleMessageTracer());
        }
    
        public void Validate(ServiceEndpoint endpoint)
        {
          return;
        }
    
        #endregion
    
        #region IConfigurationSectionHandler Members
    
        public object Create(object parent, object configContext, XmlNode section)
        {
          return null;
        }
    
        #endregion
      }
    
    	[DataContract(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    	//[DataContract(Namespace = "")]
    	[Serializable()]
    	public class UserNameTokenToken
    	{
    		[DataMember()]
    		public UserNameToken UsernameToken;
    
    		public UserNameTokenToken(UserNameToken token)
    		{
    			UsernameToken = token;
    		}
    	}
    
    	[DataContract(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    	//[DataContract(Namespace = "")]
    	[Serializable()]
    	public class UserNameToken
    	{
    		[DataMember(Order = 1)]
    		public string Username = string.Empty;
    		[DataMember(Order = 2)]
    		public string Password = string.Empty;
    
    		public UserNameToken(string uname, string pass)
    		{
    			Username = uname;
    			Password = pass;
    		}
    
    	}
