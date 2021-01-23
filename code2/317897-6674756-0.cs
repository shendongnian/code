    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "text/xml";
                string xml = @"<foo><bar>baz</bar></foo>";
                string url = "http://provideraddress.com/?xml=myxml";
                string response = client.UploadString(url, xml);
                Console.WriteLine(response);
            }
        }
    }
