    public interface IvisitorAPI
    {
        bool SaveOrder(Object order);
    }
    
    
    
    public class visitorApiIP : IvisitorAPI
    {
        public string HostName { get; set; }
        public int Port { get; set; }
    
        public visitorApiIP(string hostname, int port)
        {
            HostName = hostname;
            Port = port;
        }
    
    
        public bool SaveOrder(Object order)
        {
            //save the order using hostname and ip
            //...
            //....
            return true;
        }
    }
