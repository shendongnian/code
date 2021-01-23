        private static string Post ( string Url, string Method, string Content, string ContentType = "application/json", WebHeaderCollection headers = null )
        {
            var address = new Uri(Url);
            var request = WebRequest.Create(address) as HttpWebRequest;
            request.Method = Method;
            if (headers != null)
                request.Headers.Add(headers);
            if (!String.IsNullOrEmpty(Content))
            {
                var bytes = Encoding.UTF8.GetBytes(Content);
                request.ContentLength = bytes.Length;
                request.ContentType = ContentType;
                using (var pStream = request.GetRequestStream())
                {
                    pStream.Write(bytes, 0, bytes.Length);
                }
            }
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
        }
