    public static class ObjectExtensions
    {
        public static T ToObject<T>(this IDictionary<string, object> source)
            where T : class, new()
        {
                T someObject = new T();
                Type someObjectType = someObject.GetType();
    
                foreach (KeyValuePair<string, object> item in source)
                {
                    someObjectType.GetProperty(item.Key).SetValue(someObject, item.Value, null);
                }
    
                return someObject;
        }
    
        public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );
                            
        }
    }
    
    class A
    {
        public string Prop1
        {
            get;
            set;
        }
    
        public int Prop2
        {
            get;
            set;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("Prop1", "hello world!");
            dictionary.Add("Prop2", 3893);
            A someObject = dictionary.ToObject<A>();
    
            IDictionary<string, object> objectBackToDictionary = someObject.AsDictionary();
        }
    }
