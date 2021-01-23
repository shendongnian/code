    public abstract class MyBaseClass
    {
        public string MyCommonString { get; set; }
    }
    //This class definition lives in the DLL and remains untouched
    public class Foo
    {
        public Foo() { }
    }
    
    //This partial class definition lives in [insert new project name here]
    public partial class Foo : MyBaseClass
    {
        public Foo () { }
    }
