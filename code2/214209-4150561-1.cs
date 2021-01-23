        public static HttpWebResponse DoFormPost(this HttpWebRequest request, string postVals, int timeoutSeconds)
        {
            request.Method = "POST";
            request.Timeout = timeoutSeconds * 0x3e8;
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = false;
            byte[] bytes = Encoding.UTF8.GetBytes(postVals);
            request.ContentLength = bytes.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            return (HttpWebResponse)request.GetResponse();
        }
