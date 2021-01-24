    public class RootObject
    {
        public string name { get; set; }
        public List<RootObject> children { get; set; }
    }
    var jsonString = File.ReadAllText(jsonFile);
    
    var result = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
    foreach(var row in result)
    {
        Console.WriteLine(row.name);
    }
