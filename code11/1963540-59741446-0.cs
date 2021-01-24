    public class MyClass {
        private Type _myType = null;
    
        [JsonIgnore]
        public Type MyType {get { return _myType; }   set { _myType = value; } }
    
        public String StoredType {  
            get { return _myType.ToString(); }     
            set { _myType = Activator.CreateInstance(value); }
        }
    
        public string Name { get;set; }
    }
