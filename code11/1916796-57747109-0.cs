c#
        try
                {
                    HttpClient httpClient = new HttpClient();
                    Uri uri = new Uri("http://localhost:8080/lock/");
                    
                    HttpStringContent content = new HttpStringContent(
                        "{ \"pass\": \"theMorteza@1378App\" }",
                        UnicodeEncoding.Utf8,
                        "application/json");
                    
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(
                        uri,
                        content);
                    
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
and there is the code in the web server:
c#
        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();
        private static string LockTheScreen(HttpListenerRequest request)
        {
            var inputStream = request.InputStream;
            try
            {
                using (StreamReader sr = new StreamReader(inputStream))
                {
                    JToken pass = JToken.Parse(sr.ReadToEnd());
                    if (pass.Value<string>("pass") == "theMorteza@1378App")
                    {
                        LockWorkStation();
                    }
                }
            }
            catch (Exception)
            {
                return "fail";
            }
            return "fail";
        }
**Note:** you can find how to make a simple web server [here](https://codehosting.net/blog/BlogEngine/post/Simple-C-Web-Server)  
**But:** you must install the web server and grant it's access for users.
