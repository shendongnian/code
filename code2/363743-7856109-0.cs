    public class Response
    {
        public Keys Keys { get; set; }
    }
    public class Keys
    {
        public string RegistrationKey { get; set; }
        public string ValidationStatus { get; set; }
        public string ValidationDescription { get; set; }
        public List<Properties> PropertiesList { get; set; }
    }
    public class Properties
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
