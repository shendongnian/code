    public abstract class MyBaseClass
    {
        public string MyCommonString { get; set; }
    }
    
    public class Foo : MyBaseClass
    {
        public MyBaseClass() { }
    }
    //Create instance of foo
    Foo myFoo = new Foo();
    //MyCommonString is accessible since you inherited from base
    string commonString = myFoo.MyCommonString;
