c#
    private static readonly HttpClient _httpclient = new HttpClient();
        private void NewCode()
        {
            _httpclient.Timeout = new TimeSpan(0, 0, 5);
            _httpclient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            _httpclient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpclient.DefaultRequestHeaders.Add("Accept-Language", "it");
            var t = Task.Run(TEST3);
            t.Wait();
            string tmp = t.Result;
            MessageBox.Show(tmp);
        }
        private static async Task<String> TEST3()
        {
            try
            {
                HttpRequestMessage x = new HttpRequestMessage(HttpMethod.Post, "http://myurl.com");
                Dictionary<string, string> postParams = new Dictionary<string, string>();
                postParams.Add("Param", "Value");
                x.Content = new FormUrlEncodedContent(postParams);
                HttpResponseMessage Req = await _httpclient.SendAsync(x, HttpCompletionOption.ResponseHeadersRead);
                Req.EnsureSuccessStatusCode();
                Stream str = await Req.Content.ReadAsStreamAsync();
                Encoding encoding2 = Encoding.GetEncoding("utf-8");
                StreamReader streamReader = new StreamReader(str, encoding2);
                return streamReader.ReadToEnd();
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpcompletionoption?view=netframework-4.8
