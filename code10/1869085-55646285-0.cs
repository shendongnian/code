    public class RootObject
    {
        public Addition Addition { get; set; }
    }
    var result = JsonConvert.DeserializeObject<RootObject>(json);
    Console.WriteLine(result.Addition.Easy.First());
