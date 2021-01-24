            static WebBrowser webBrowser;
            static void Main(string[] args)
            {
                webBrowser = new WebBrowser();
                NavigateToUrl("stackoverflow.com");
                webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
                Console.ReadLine();
            }
    
            static void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
    
               /// Print example but you can do whatever you want here
               /// 
                // Print the document now that it is fully loaded.
                ((WebBrowser)sender).Print();
    
                // Dispose the WebBrowser now that the task is complete. 
                ((WebBrowser)sender).Dispose();
            }
    
            private static void NavigateToUrl(String address)
            {
                //
                var uri = GetUriFromAddress(address);
                try
                {
                    if (uri != null)
                    {
                        /// set uri to the webBrowser object
                        webBrowser.Url = uri;
                        webBrowser.Navigate(uri);
                    }
                    else
                        return;
                }
                catch (UriFormatException)
                {
                    return;
                }
            }
    
            private static Uri GetUriFromAddress(String address)
            {
                // can accept both HTTP and HTTPS URLs as valid 
                Uri uriResult;
                if (Uri.TryCreate(address, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                    return uriResult;
                else
                    return null;          
    
            }
