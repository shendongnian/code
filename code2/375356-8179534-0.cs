       {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add(DataHolder.USER_ID, "0");
            param.Add(DataHolder.DEFAULT_LOCATION_ID, "0");
            PostClient proxy = new PostClient(param);
            proxy.DownloadStringCompleted += new PostClient.DownloadStringCompletedHandler(proxy_DownloadStringCompleted);           
            proxy.DownloadStringAsync(new Uri(DataHolder.mainConfigFetchUrl, UriKind.Absolute));
         
        }
        void proxy_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                //Process the result... 
                string data = e.Result;
            }
        }
