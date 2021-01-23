    using FirstNamespace;
    using OtherObject = SecondNamespace.MyObject;
    
    public class Foo
    {
        public void Bar()
        {
            MyObject first = new MyObject;//will be the MyObject from the first namespace
            OtherObject second = new OtherObject;
        }
    }
