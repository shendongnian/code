    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            // do something with the request
            // BTW, this is how you can change timeouts or use cookies
            return request;
        }
    }
