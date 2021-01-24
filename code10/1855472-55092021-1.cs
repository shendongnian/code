    [ModelBinder(typeof(LegacyBinder))]
    public class MyServiceRequest
    {
        public string Count { get; set; }
        public List<string> Params { get; set; }
    }
