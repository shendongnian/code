    class MyClass
    {
        //Implementation
        public void Foo() {}
    }
    class SomethingYouWantToTest
    {
        public bool MyMethod(MyClass c)
        {
            //Code you want to test
            c.Foo();
        }
    }
