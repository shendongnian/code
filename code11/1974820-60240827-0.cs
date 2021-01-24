    class Program
    {
        static void Main(string[] args)
        {
            LoadJson();
        }
        public static void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\\Users\\user\\source\\repos\\RecursiveParseJSON\\RecursiveParseJSON\\data.json")) 
            {
                string json = r.ReadToEnd();
                JsonObject datas = JsonConvert.DeserializeObject<JsonObject>(json);
            }
        }
    }
  
    public class JsonObject
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public List<string> count { get; set; }
        public List<Doc> list { get; set; }
    }
    public class Doc
    {
        public string title { get; set; }
        public int rotate { get; set; }
        public string sort_key { get; set; }
        public string tag_ids { get; set; }
        public string doc_id { get; set; }
        public string co_token { get; set; }
        public string p { get; set; }
        public string t { get; set; }
        public string c { get; set; }
        public string updated { get; set; }
    }
