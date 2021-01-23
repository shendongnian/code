    interface IInterface<T>
    {
        Type GetMyType();
    }
    class MyClass1 : IInterface<int>
    {
        public Type GetMyType()
        {
            return typeof(int);//each subclass must be return own generic type
        }
    }
    static void Main()
    {
        new MyClass1().GetMyType()==typeof(int);//Is True
    }
