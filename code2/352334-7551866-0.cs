        public class ClassA 
        {
            protected string name;
            public string Name { get { return name; } public set { name = value; } }
        }
    
    public class ClassB : ClassA
        {
             public new string Name { get { return base.name; } }
        }
