    public abstract class MyBaseClass
    {
        public string MyCommonString { get; set; }
    }
    
    public partial class Foo : MyBaseClass
    {
        public MyBaseClass() { }
    }
