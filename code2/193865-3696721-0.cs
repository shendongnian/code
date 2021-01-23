    interface ITest
    {
        object t { get; }
        bool DoTest();
    }
    interface ITest<T> : ITest
    {
        T t { get; }
    }
