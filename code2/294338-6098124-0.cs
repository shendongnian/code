    class Slice
    {
        public IList<XValue> XValues {get; set; }
    }
    
    class XValue
    {
        public IList<YValue> YValues {get; set; }
    }
    
    class YValue
    {
        // ...
    }
    
    var slices = new List<Slice>();
