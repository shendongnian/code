    public class A
    {
        protected string SomeString;
        public string SomeOtherString;
    }
    
    public class B : A
    {
        public string Wrapped
        {
            get { return this.SomeString; }
        }
    }
    
    ...
    
    var a = new A();
    var s = a.SomeOtherString; // valid
    var s2 = a.SomeString; // Error
    
    var b = new B();
    var s3 = b.Wrapped; // valid
