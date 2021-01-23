    public class MyClass : IMyInterface<MyClass>
    {
        public T ReturnClassInstance()
        {
            return this;
        }
    }
