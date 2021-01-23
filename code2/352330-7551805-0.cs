    public class ClassA
    {
        private string _name;
        public string Name { get { return _name; } protected set { _name = value; } }
    }
    
    public class ClassB : ClassA
    {
      /* nothing left to do - you can set Name in here but not from outside */
    }
