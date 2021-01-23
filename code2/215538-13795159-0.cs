    namespace ExampleWebBrowser
    {
        public partial class Form1 : Form
        {
             [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
             public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
             CookedWebClient client = new CookedWebClient();
		
             ..
             ..
             ..
		
             private void usingWebBrowserWithWebClientCookies(string url)
             {
                CookieCollection cookies = client.Cookies.GetCookies(url);
                for (int i = 0; i < cookies.Count; i++)
                {
                   Cookie c = cookies[i];
                   InternetSetCookie(url, c.Name, c.Value);
                }
                webBrowser1.Navigate(url);
             }
         }
		
         public class CookedWebClient : WebClient
         {
            CookieContainer cookies = new CookieContainer();
            public CookieContainer Cookies { get { return cookies; } }
            protected override WebRequest GetWebRequest(Uri address)
            {
               WebRequest request = base.GetWebRequest(address);
               if (request.GetType() == typeof(HttpWebRequest))
                  ((HttpWebRequest)request).CookieContainer = cookies;
               return request;
            }
         }
    }
