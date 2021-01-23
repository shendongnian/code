    public class MyClass
    {
        private readonly string _name;
        public MyClass(string name)
        {
            _name = name;
        }
    
        public string Name 
        {
            get { return _name; }
        }
    }
