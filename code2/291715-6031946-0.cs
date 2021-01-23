    using Foo.Uber;
    using FooUberBar = Foo.Uber.Bar
    
    namespace MyStuff.Foo
    {
        class SomeClass{
            void DoStuff(){
                // I want to reference the outer "absolute" Foo.Uber
                // but the compiler thinks I'm refering to MyStuff.Foo.Uber
                var x = FooUberBar();
            }
        }
    }
