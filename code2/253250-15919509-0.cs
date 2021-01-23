         public void Download()
         { 
             DownloadString((result) =>
             {
                 //!!Require to import Newtonsoft.Json.dll for JObject!!
                 JObject fdata= JObject.Parse(result);
                 listbox1.Items.Add(fdata["name"].ToString());
                 
             }, "http://graph.facebook.com/zuck");
        }
        public void DownloadString(Action<string> callback, string url)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (p, q) =>
            {
                if (q.Error == null)
                {
                    callback(q.Result);
                }
            };
            client.DownloadStringAsync(new Uri(url));
        }
