    class Response
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
    static void Main(string[] args)
    {
        string body = @"{'ResponseCode':0,'ResponseMessage':'71a88836-57f0-4b0e-a59c-071ea6d6f1de'}";
        var response = JsonConvert.DeserializeObject<Response>(body );
    }
