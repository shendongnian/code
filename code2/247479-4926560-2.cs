    [Serializable]
    public class MySerializableClass
    {
        public MySerializableClass()
        {
            
        }
    
        // This string serializes ok
        public string MyStringProperty { get; set; } 
    
        // Because this property is public in scope it must be serializable
        // because it will be translated at a public scope. This will throw
        // an exception
        public myNonSerializableClass NotSerializableObject { get; set; }   
    
        // Because this property is private in scope, it will not be included
        // in any serialization calls, so it will not throw an exception, but
        // it will also not be available in whatever remote class calls it.
        private myNonSerializableClass SerializableObject { get; set; } 
    
        // Because this property object is serializable in code it will be
        // ok to make it public because it will natively serialize itself
        public MyOtherSerializableClass OtherSerializableObject { get; set; }
    
    }
