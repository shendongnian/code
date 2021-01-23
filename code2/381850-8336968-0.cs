    [ServiceContract]
    public interface: IMyContract
    {
         [OperationContract]
         [WebInvoke(Method = "GET", UriTemplate = "getXml")]
         Stream ReturnAnyXml();   
    }
    
    public class MyService : IMyContract
    {
        public Stream ReturnAnyXml()
        {
            WebOperationContext CurrentWebContext = WebOperationContext.Current;
            if (CurrentWebContext != null)
            {
                CurrentWebContext.OutgoingResponse.ContentType = "text/xml";	
                String AnyXml = "<tag></tag>";
                return new MemoryStream(Encoding.UTF8.GetBytes(AnyXml)); 
            }
        }      
    }  
