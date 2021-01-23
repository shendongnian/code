    using Outer = Foo.Uber;
    
    namespace MyStuff.Foo
    {
        class SomeClass{
            void DoStuff(){                
                var x = new Outer.Bar(); //outer class
            }
        }
    }
