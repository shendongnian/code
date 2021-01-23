    interface IMyClass
    {
        void Foo();
    }
    class MyClass : IMyClass
    {
        //Implementation
        public void Foo() {}
    }
    class SomethingYouWantToTest
    {
        public bool MyMethod(IMyClass c)
        {
            //Code you want to test
            c.Foo();
        }
    }
