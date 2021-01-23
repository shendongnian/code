    public class MyClass
    {
        public string MyProp1 { get; set; }
        public string MyProp2 { get; set; }
    
        public static readonly MyClass Empty = new MyClass();
    
        public Boolean HasData()
        {
        	return !Empty.Equals(this);
        }
    
        public Boolean IsEmpty()
        {
    		return Empty.Equals(this);
        }
    }
