//instantiate a string that will house our cookie header
public static string _cookieHeader;
//you might want to make it private to prevent abuse
//but this example is just for demonstration
//the thing is we need a string to house our headers in scope of both the WebView and the HttpClient
//extend the WebViewClient
        private class ExtWebViewClient : WebViewClient
        {
            public override void OnPageFinished(WebView view, string url)
            {
            //I get the cookies when the page finishes loading because
            //then we know the cookie has our login cred header
            //also, most of the previous examples got the cookies OnPageFinished
             
            TheFragment5._cookieHeader = Android.Webkit.CookieManager.Instance.GetCookie(url);
            }
        }
Then we need another class for the `HttpClient` and `HttpClientHandler` ... mine scans a webpage for notification text. 
            public async void GetNotificationText(string url)
            {
                await Task.Run(() =>
                {
                   /* this line is pretty important, 
                    we need to instantiate an HttpClientHandler 
                    then set it's UseCookies property to false
                    so that it doesn't override our cookies
                  */
                    HttpClientHandler handler = new HttpClientHandler() { UseCookies = false };
                    try
                    {
                        var _ctxxx = Android.App.Application.Context;
                        Uri _notificationURI = new Uri("https://bitchute.com/notifications/");
                        //instantiate HttpClient using the handler
                        using (HttpClient _client = new HttpClient(handler))
                        {
                         //this line is where the magic happens; 
                         //we set the DefaultRequestHeaders with the cookieheader we got from WebViewClient.OnPageFinished                
                         _client.DefaultRequestHeaders.Add("Cookie", TheFragment5._cookieHeader);
                            //do a GetAsync request with our cookied up client
                            var getRequest = _client.GetAsync("https://bitchute.com/notifications/").Result;
                            //resultContent is the authenticated html string response from the server, ready to be parsed =]
                            var resultContent = getRequest.Content.ReadAsStringAsync().Result;
                            /*
                            I was writing to console to check the                
                            response.. for me, I am now getting  
                            the authenticated notification html 
                            page
                            */
                            Console.WriteLine(resultContent);
                        }
                    }   
                }
            }
Hope this helps you, posting for future reference, especially for people using Xamarin.Android.
