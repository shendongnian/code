        class Program
        {
            static void Main(string[] args)
            {
                // NOTE: This is how I load the JSON data into the new type.
                var obj = JsonConvert.DeserializeObject<MyCustomDynamicObject>("{name:'name1', proxy:'string'}");
                var proxy = obj.Proxy;
                var name = obj.Name;
            }
        }
        public class MyDynamicObject : DynamicObject
        {
            // Implements the functionality to store dynamic properties in 
            // dictionary.
            // NOTE: This base class does not have any declared properties.
        }
    
        // NOTE: This is the actual concrete type that has declared properties
        public class MyCustomDynamicObject : MyDynamicObject
        {
            public string Name { get; set; }
            public string Proxy { get; set; }
        }
