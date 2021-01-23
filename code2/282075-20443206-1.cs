    public class AmazonSigningMessageInspector : IClientMessageInspector
    {
        private string accessKeyId = "";
        private string secretKey = "";
    
        public AmazonSigningMessageInspector(string accessKeyId, string secretKey)
        {
            this.accessKeyId = accessKeyId;
            this.secretKey = secretKey;
        }
    
        public Object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel) 
        {
            string operation = Regex.Match(request.Headers.Action, "[^/]+$").ToString();
            DateTime now = DateTime.UtcNow;
            String timestamp = now.ToString("yyyy-MM-ddTHH:mm:ssZ");
            String signMe = operation + timestamp;
            Byte[] bytesToSign = Encoding.UTF8.GetBytes(signMe);
    
            Byte[] secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            HMAC hmacSha256 = new HMACSHA256(secretKeyBytes);
            Byte[] hashBytes = hmacSha256.ComputeHash(bytesToSign);
            String signature = Convert.ToBase64String(hashBytes);
    
            request.Headers.Add(new AmazonHeader("AWSAccessKeyId", accessKeyId));
            request.Headers.Add(new AmazonHeader("Timestamp", timestamp));
            request.Headers.Add(new AmazonHeader("Signature", signature));
            return null;
        }
    
        void IClientMessageInspector.AfterReceiveReply(ref System.ServiceModel.Channels.Message Message, Object correlationState)
        {
        }
    }
    
    public class AmazonSigningEndpointBehavior : IEndpointBehavior
    {
        private string accessKeyId = "";
        private string secretKey = "";
    
        public AmazonSigningEndpointBehavior(string accessKeyId, string secretKey)
        {
            this.accessKeyId = accessKeyId;
            this.secretKey = secretKey;
        }
    
        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new AmazonSigningMessageInspector(accessKeyId, secretKey));
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatched)
        {
        }
    
        public void Validate(ServiceEndpoint serviceEndpoint)
        {
        }
    
        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParemeters)
        {
        }
    }
    
    public class AmazonHeader : MessageHeader
    {
        private string m_name;
        private string value;
    
        public AmazonHeader(string name, string value)
        {
            this.m_name = name;
            this.value = value;
        }
    
        public override string Name
        {
            get { return m_name; }
        }
        public override string Namespace
        {
            get { return "http://security.amazonaws.com/doc/2007-01-01/"; }
        }
        protected override void OnWriteHeaderContents(System.Xml.XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteString(value);
        }
    }
