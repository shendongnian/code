    public class CookieAwareWebClient : WebClient
    {
        public CookieAwareWebClient ()
    	{
            CookieContainer = new CookieContainer();
    	}
        public CookieContainer CookieContainer { get; set; }
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            ((HttpWebRequest)request).CookieContainer = CookieContainer;
            return request;
        }
    }
    
    public class Program
    {
        static void Main()
        {
            using (var client = new CookieAwareWebClient())
            {
                var values = new NameValueCollection
                {
                    { "txtUserID", "foo" },
                    { "txtPassword", "secret" }
                };
                // Authenticate. As we are using a cookie container
                // the user will be authenticated on the next requests
                // using this client
                client.UploadValues("http://www.aimlifes.com/office/Login.aspx", values);
                // The user is now authenticated:
                var result = client.DownloadString("http://www.aimlifes.com/office/ReceiveRecharge.aspx");
                Console.WriteLine(result);
            }
        }
    }
