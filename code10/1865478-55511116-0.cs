cs
private async Task<WebResponse> ExecuteHttpWebRequest()
        {
            var selectedMethode = Methode.SelectedItem as TextBlock;
            string method = selectedMethode.Text;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Query.Text);
            WebHeaderCollection myWebHeaderCollection = webRequest.Headers;
            myWebHeaderCollection = BuildHeaderCollection(myWebHeaderCollection);
            myWebHeaderCollection = AddAuthorization(myWebHeaderCollection);
            webRequest.PreAuthenticate = true;
            webRequest.Method = method;
            webRequest.UserAgent = "something";
            if (webRequest.Method == "POST" || webRequest.Method == "PUT" || webRequest.Method == "PATCH")
            {
                byte[] data = Encoding.ASCII.GetBytes(Body.Text);
                webRequest.ContentLength = data.Length;
                using (var stream = webRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return await webRequest.GetResponseAsync();
        }
