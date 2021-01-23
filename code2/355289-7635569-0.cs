    interface IMyInterface
    {
        void Foobar();
    }
    
    class MyClass<T>
    {
        public T Model
        {
            get;
            protected set;
        }
    }
    
    private void MyMethod<T>(MyClass<T> param) where T : IMyInterface
    {
        param.Model.Foobar();
    }
