    void DownloadData(string cURL) 
            {
                WebClient webClient = new WebClient();
    
                try
                {
                    webClient.DownloadStringCompleted += new System.Net.DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
                    webClient.DownloadStringAsync(new Uri(cURL));
                }
                catch
                {
                    webClient.Dispose();
                    throw;
                }
            }
            
            static void webClient_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
            {
                WebClient webClient = (WebClient)sender;
    
                webClient.DownloadStringCompleted -= webClient_DownloadStringCompleted;
    
                try
                {
    
                }
                finally
                {
                    webClient.Dispose();
                }
            }
