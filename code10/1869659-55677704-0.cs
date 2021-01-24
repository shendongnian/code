    namespace ClassLibrary
    {
        public class Base
        {
            public string myString;
    
            public Base(string str)
            {
                myString = myString ?? "Hi";
                myString += str;
            }
        }
    
        public class Derived : Base
        {
            public Derived() : base(" world")
            {
                base.myString = "Hello";
            }
        }
    }
