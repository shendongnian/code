    public class MyData
    {
        public string Id { set; get; }
        public string Times { set; get; }
        public Data Data { set; get; }
        public string Number { set; get; }
    }
    public class Data
    {
        public string Id { set; get; }
        public string Code { set; get; }
        public string Description { set; get; }
    }
    var lines = File.ReadAllLines(@"C:\Temp\data.txt").Where(line => !line.StartsWith("2019"));
    var jsonString = "[" + String.Join("", lines) + "]";
    jsonString = jsonString.Replace("}", "},");
    jsonString = jsonString.Replace("},,", "},");
    var myObjectDT = JsonConvert.DeserializeObject<List<MyData>>(jsonString);
    foreach(var item in myObjectDT)
    {
        string line = JObject.FromObject(item).ToString(Formatting.None);
        //write line to file
    }
