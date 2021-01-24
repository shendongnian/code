    using System.IO;
    using Newtonsoft.Json;
    public class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader(@"file.json"))
            {
                string json = r.ReadToEnd();
                var root = JsonConvert.DeserializeObject<RootObject>(json);
                var brands = root.Documents[0].Brands; // brands = {"ZZZ"}
            }
        }
    }
    public class RootObject
    {
        public Document[] Documents { get; set; }
    }
    public class Document
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string ApiKey { get; set; }
        public string ConsumerName { get; set; }
        public bool IsAdmin { get; set; }
        public string[] Brands { get; set; }
        public bool IsSdkUser { get; set; }
    }
