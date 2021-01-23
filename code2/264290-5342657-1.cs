    namespace Outer.Inner
    {
        class Foo
        {
            public static void Bar() {}
        }
    }
    
    namespace Outer.OtherInner
    {
        class Test1        
        {
            static void Method()
            {
                // Resolved to Outer.Inner.Foo.Bar()
                Inner.Foo.Bar();
            }
        }
    }
        
    namespace OtherOuter
    {
        using Outer;
        
        class Test2
        {
            static void Main()
            {
                // This is invalid
                Inner.Foo.Bar();
            }
        }
    }
