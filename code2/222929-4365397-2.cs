    public class ValueHolder
    {
        public ValueType[] Values { get; set; }
        public string[] NonValueType { get; set; }
    }
    public class SomeValueType<T> where T:ValueHolder
    {
        Dictionary<string, T> tempDict = new Dictionary<string, T>();
     
        public SomeValueType(T val,string keyName)
        {
            if(!tempDict.Keys.Contains(keyName))
                 tempDict.Add(keyName, val);
        }
        
    }
