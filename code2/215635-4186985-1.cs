    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0(Windows; U; Windows NT 5.1; en-US; rv:1.8.0.5)Gecko/20060719 Firefox/1.5.0.5";
                var values = new NameValueCollection
                {
                    { "login_username", "mehdi" },
                    { "login22", "654321" },
                    { "go", "submit" }
                };
                var result = client.UploadValues("http://example.com", values);
                // TODO: handle the result here like
                Console.WriteLine(Encoding.Default.GetString(result));
            }
        }
    }
