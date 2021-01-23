    [WebService]
    public class MySvc : WebService {
        
        [WebMethod (Description="Proxy for MyService")]
        public String Proxy()
        {return "<h1>MyHeader</h1>"}
    }
