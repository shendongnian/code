    public class CustomClientBehavior : IEndpointBehavior
    {
        string _username;
        string _password;
        public CustomClientBehavior(string username, string password)
        {
            _username = username;
            _password = password;
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            CustomInspector inspector = new CustomInspector(_username, _password);
            clientRuntime.MessageInspectors.Add(inspector);
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
    public class CustomClientBehaviorExtensionElement : BehaviorExtensionElement
    {
        string _username;
        string _password;
        public CustomClientBehaviorExtensionElement(string username, string password)
        {
            _username = username;
            _password = password;
        }
        public override Type BehaviorType
        {
            get { return typeof(CustomClientBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new CustomClientBehavior(_username, _password);
        }
    }
    public class CustomInspector : IClientMessageInspector
    {
        string _username;
        string _password;
        public CustomInspector(string username, string password)
        {
            _username = username;
            _password = password;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            return;
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            request.Headers.Clear();
            string headerText = "<wsse:UsernameToken xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">" +
                                    "<wsse:Username>{0}</wsse:Username>" +
                                    "<wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" +
                                    "{1}</wsse:Password>" +
                                "</wsse:UsernameToken>";
            headerText = string.Format(headerText, _username, _password);
            XmlDocument MyDoc = new XmlDocument();
            MyDoc.LoadXml(headerText);
            XmlElement myElement = MyDoc.DocumentElement;
            System.ServiceModel.Channels.MessageHeader myHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", myElement, false);
            request.Headers.Add(myHeader);
            return Convert.DBNull;
        }
    }
