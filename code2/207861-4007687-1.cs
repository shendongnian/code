    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.UserAgent] = "linkToShare - HTTPWebRequest";
                var valuesToPost = new NameValueCollection
                {
                    { "param1", "value1" },
                    { "param2", "value2" },
                };
                var result = client.UploadValues("http://127.0.0.1:5432", valuesToPost);
                Console.WriteLine(Encoding.UTF8.GetString(result));
            }
        }
    }
