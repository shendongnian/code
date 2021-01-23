    public class RequestGAMELIST
    {
        public AutoResetEvent XMLReceived = new AutoResetEvent();
        
        public void ParseRequest( string request )
        {
            int index = request.IndexOf(':') + 2;
            XML = request.Substring(index, request.Length - index);
            XMLReceived.Set();
        }
    }
