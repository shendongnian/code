    using System;
    using System.Collections;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Http;
    
    using CookComputing.XmlRpc;
    
    using System.Net;
    using System.IO;
    
    public class _
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("https://127.0.0.1:5678/");
            listener.Start();
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                ListenerService svc = new StateNameService();
                svc.ProcessRequest(context);
            }
    
            Console.WriteLine("Press <ENTER> to shutdown");
            Console.ReadLine();
        }
    }
    
    public class StateNameService : ListenerService
    {
        [XmlRpcMethod("examples.getStateName")]
        public string GetStateName(int stateNumber)
        {
            if (stateNumber < 1 || stateNumber > m_stateNames.Length)
                throw new XmlRpcFaultException(1, "Invalid state number");
            return m_stateNames[stateNumber - 1];
        }
    
        string[] m_stateNames
          = { "Alabama", "Alaska", "Arizona", "Arkansas",
            "California", "Colorado", "Connecticut", "Delaware", "Florida",
            "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", 
            "Kansas", "Kentucky", "Lousiana", "Maine", "Maryland", "Massachusetts",
            "Michigan", "Minnesota", "Mississipi", "Missouri", "Montana",
            "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", 
            "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma",
            "Oregon", "Pennsylviania", "Rhose Island", "South Carolina", 
            "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", 
            "Washington", "West Virginia", "Wisconsin", "Wyoming" };
    }
    
    public abstract class ListenerService : XmlRpcHttpServerProtocol
    {
        public virtual void ProcessRequest(HttpListenerContext RequestContext)
        {
            try
            {
                IHttpRequest req = new ListenerRequest(RequestContext.Request);
                IHttpResponse resp = new ListenerResponse(RequestContext.Response);
                HandleHttpRequest(req, resp);
                RequestContext.Response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                // "Internal server error"
                RequestContext.Response.StatusCode = 500;
                RequestContext.Response.StatusDescription = ex.Message;
            }
        }
    }
    
    public class ListenerRequest : CookComputing.XmlRpc.IHttpRequest
    {
        public ListenerRequest(HttpListenerRequest request)
        {
            this.request = request;
        }
    
        public Stream InputStream
        {
            get { return request.InputStream; }
        }
    
        public string HttpMethod
        {
            get { return request.HttpMethod; }
        }
    
        private HttpListenerRequest request;
    }
    
    public class ListenerResponse : CookComputing.XmlRpc.IHttpResponse
    {
        public ListenerResponse(HttpListenerResponse response)
        {
            this.response = response;
        }
    
        string IHttpResponse.ContentType
        {
            get { return response.ContentType; }
            set { response.ContentType = value; }
        }
    
        TextWriter IHttpResponse.Output
        {
            get { return new StreamWriter(response.OutputStream); }
        }
    
        Stream IHttpResponse.OutputStream
        {
            get { return response.OutputStream; }
        }
    
        int IHttpResponse.StatusCode
        {
            get { return response.StatusCode; }
            set { response.StatusCode = value; }
        }
    
        string IHttpResponse.StatusDescription
        {
            get { return response.StatusDescription; }
            set { response.StatusDescription = value; }
        }
    
        private HttpListenerResponse response;
    }
    
    public class StateNameServer : MarshalByRefObject, IStateName
    {
      public string GetStateName(int stateNumber)
      {
        if (stateNumber < 1 || stateNumber > m_stateNames.Length)
          throw new XmlRpcFaultException(1, "Invalid state number");
        return m_stateNames[stateNumber-1]; 
      }
    
      public string GetStateNames(StateStructRequest request)
      {
        if (request.state1 < 1 || request.state1 > m_stateNames.Length)
          throw new XmlRpcFaultException(1, "State number 1 invalid");
        if (request.state2 < 1 || request.state2 > m_stateNames.Length)
          throw new XmlRpcFaultException(1, "State number 1 invalid");
        if (request.state3 < 1 || request.state3 > m_stateNames.Length)
          throw new XmlRpcFaultException(1, "State number 1 invalid");
        string ret = m_stateNames[request.state1-1] + " "
          + m_stateNames[request.state2-1] + " " 
          + m_stateNames[request.state3-1];
        return ret;
      }
    
      string[] m_stateNames 
        = { "Alabama", "Alaska", "Arizona", "Arkansas",
            "California", "Colorado", "Connecticut", "Delaware", "Florida",
            "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", 
            "Kansas", "Kentucky", "Lousiana", "Maine", "Maryland", "Massachusetts",
            "Michigan", "Minnesota", "Mississipi", "Missouri", "Montana",
            "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", 
            "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma",
            "Oregon", "Pennsylviania", "Rhose Island", "South Carolina", 
            "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", 
            "Washington", "West Virginia", "Wisconsin", "Wyoming" };
    }
