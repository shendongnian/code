    public static class SharedStorage
    {
       private static Dictionary<string, object> _data = new Dictionary<string,object>();
       public static Dictionary<string, object> Data { get { return _data; } }
    }
