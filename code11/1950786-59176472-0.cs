        public class ListImage
        {
            public List<Image> test;
        }
        public class Image
        {
            public string url;
            public string width;
            public string height;
        }
        static void Main(string[] args)
        {
            var fileContent = File.ReadAllText("path to your file");
            var deserializedListImage = JsonConvert.DeserializeObject<ListImage>(fileContent);
        }
  [1]: https://www.newtonsoft.com/json
