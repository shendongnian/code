    public class SubKey
    {
        public string buffer { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
        public string value { get; set; }
        public bool hasValue { get; set; }
    }
    public class Error
    {
        public object exception { get; set; }
        public string errorMessage { get; set; }
    }
    public class RootObject
    {
        public object childNodes { get; set; }
        public object children { get; set; }
        public string key { get; set; }
        public SubKey subKey { get; set; }
        public bool isContainerNode { get; set; }
        public object rawValue { get; set; }
        public object attemptedValue { get; set; }
        public List<Error> errors { get; set; }
        public int validationState { get; set; }
    }
    ...
    var completeObject = JsonConvert.DeserializeObject<RootObject>(response.content);
