    //Library.dll
    namespace Library
    {
        using System;
        public static class Factory
        {
            public static IFoo CreateFoo()
            {
                return new Foo();
            }
        }
        public interface IFoo
        {
            void DoSomething();
        }
        class Foo : IFoo
        {
            public void DoSomething()
            {
                Console.WriteLine("The internal foos public method is called from another assembly!!");
            }
        }
    }
