    public class MyFactory
    {
        public MyInterface createMyClass() 
        {
            return new MyClass() { Name = "foo", Something = 42 };
        }
    
        public MyInterface createMySecondClass() 
        {
            return new MySecondClass() { Name = "bar", SomethingElse = 4.2M };
        }
    }
