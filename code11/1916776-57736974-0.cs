    public class ActualValue
    {
        public int otherId { get; set; }
        public int id { get; set; }
        public string valuetoExtract1 { get; set; }
        public string valuetoExtract2 { get; set; }
        public string valuetoExtract3 { get; set; }
    }
    
    public class RootObject
    {
        public string option1 { get; set; }
        public string option12 { get; set; }
        public List<string> id { get; set; }
        public string filter { get; set; }
        public List<ActualValue> actualValues { get; set; }
    }
