    [Serializable]
    public class RootObject
    {
        public string version = "";
        public Data data = new Data();
    }
    
    [Serializable]
    public class Data
    {
        public List<object> sampleArray = new List<object>();
    }
    
    [Serializeable]
    public class SubData
    {
        public string name = "";
    }
