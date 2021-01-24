    void Main()
    {
        string json = File.ReadAllText(@"d:\temp\test.json");
        var response = JsonConvert.DeserializeObject<Response>(json);
        response.Dump();
    }
    
    public class Response
    {
        public string Message { get; set; }
        
        public Dictionary<string, List<string>> Errors { get; }
            = new Dictionary<string, List<string>>();
    }
