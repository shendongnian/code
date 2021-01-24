    public class Datum
    {
        public List<Datum> children { get; set; }
        public bool var { get; set; }
        public string name { get; set; }
        public bool leaf { get; set; }
        public int category_id { get; set; }
    }
    public class RootObject
    {
        public List<Datum> data { get; set; }
    }
