    public HttpStatusCode GetHeaders(string url)
        {
            HttpStatusCode result = default(HttpStatusCode);
            var request = HttpWebRequest.Create(url);
            request.Method = "HEAD";
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response != null)
                {
                    result = response.StatusCode;
                    response.Close();
                }
            }
            return result;
        }
