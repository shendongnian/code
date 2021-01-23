    public static class IAsyncResultExtensions
    {
        public static string GetResponseAsString(this IAsyncResult asyncResult)
        {
            string responseString;
            var request = (HttpWebRequest)asyncResult.AsyncState;
            using (var resp = (HttpWebResponse)request.EndGetResponse(asyncResult))
            {
                using (var streamResponse = resp.GetResponseStream())
                {
                    using (var streamRead = new StreamReader(streamResponse))
                    {
                        responseString = streamRead.ReadToEnd();
                    }
                }
            }
            return responseString;
        }
        public static HttpWebRequest SetRequestBody(this IAsyncResult asyncResult, string body)
        {
            var request = (HttpWebRequest)asyncResult.AsyncState;
            using (var postStream = request.EndGetRequestStream(asyncResult))
            {
                using (var memStream = new MemoryStream())
                {
                    var content = body;
                    var bytes = System.Text.Encoding.UTF8.GetBytes(content);
                    memStream.Write(bytes, 0, bytes.Length);
                    memStream.Position = 0;
                    var tempBuffer = new byte[memStream.Length];
                    memStream.Read(tempBuffer, 0, tempBuffer.Length);
                    postStream.Write(tempBuffer, 0, tempBuffer.Length);
                }
            }
            return request;
        }
    }
