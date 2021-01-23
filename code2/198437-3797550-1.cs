    public class ABaseClass
    {
        public ABaseClass(string s) {}
    }
    
    public class Foo : AChildClass
    {
        public AChildClass(string s) : base(s) {} //base mandatory
        public AChildClass() : base("default value") {}  //base mandatory
        public AChildClass(string s,int i) : base(s+i) {}  //base mandatory
    }
    public class AnotherBaseClass
    {
        public ABaseClass(string s) {}
        public ABaseClass():this("default value") {}
    }
    
    public class Foo : AnotherChildClass
    {
        public AnotherChildClass(string s) : base(s) {} //base optional
    }
