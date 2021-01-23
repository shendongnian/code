    // Say you have an extension method that looks like this:
    class Extensions
    {
        public static void Extend(this SomeClass foo) {}
    }
    
    // Here's how you call it
    SomeClass myClass;
    myClass.Extend();
    
    // The compiler converts it to this:
    Extensions.Extend(myClass);
