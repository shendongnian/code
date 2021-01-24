static void Main(string[] args)
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Response[]>(jsonString);
            var urls = new List<string>();
            foreach (var response in result)
            {
                foreach (var id in response.id)
                {
                    urls.Add(id.url);
                    Console.WriteLine(id.url);
                }
            }
            Console.ReadLine();
        }
And your model objects should be:
        public class Response
        {
            public string images { get; set; }
            public Url[] id { get; set; }
            public string[] answers { get; set; }
            public string type { get; set; }
            public string row { get; set; }
        }
        public class Url
        {
            public int value { get; set; }
            public string url { get; set; }
            public string content { get; set; }
        }
