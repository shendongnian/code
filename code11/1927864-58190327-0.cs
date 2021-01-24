    [Serializable]
    public class SomeData
    {
        public string h;
        public string id;
        public string lat;
    }
    
    [Serializable]
    public class CODE
    {
        public SomeData someData;
        public List<List<MyData>> feedMe;
    }
    [Serializable]
    public class MyData
    {
        public string item1;
        public string item2;
        public string item3;
    }
    
    [Serializable]
    public class Data
    {
        public CODE CODE;
    }
    
    [Serializable]
    public class RootObject
    {
        public Data data;
    }
