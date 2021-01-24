    public class Result
    {
        public string Status { get; set;}
        public string Message { get; set;}
    }
    var result = JsonConvert.DeserializeObject<Result>(json);
