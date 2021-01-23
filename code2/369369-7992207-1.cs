            try
            {
                WebClient client = new WebClient();
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
                client.DownloadStringAsync(new Uri("http://ip/services"));
            }
            catch (Exception ex)
            {
    
                Debug.WriteLine(ex.GetType().FullName);
                Debug.WriteLine(ex.GetBaseException().ToString());
            }
