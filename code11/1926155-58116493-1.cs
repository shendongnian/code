        static void Main(String[] args)
        {
            string filePath = @"D:\RnD\test.json";
            string jsonString;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader2 = new StreamReader(fileStream, Encoding.UTF8))
            {
                jsonString = streamReader2.ReadToEnd();
            }
            var results = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RootObject2>>(jsonString);
            var urls = new List<string>();
            foreach (var result in results)
            {
                foreach (var id in result.id)
                {
                    urls.Add(id.url);
                }               
            }
            foreach (var item in urls)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
