    public class MyClass : NonControllable {
        
        // Property that is not serialized.
        [NonSerialized()] 
        public string myProperty; 
    }
