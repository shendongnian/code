    class BaseClass<T, K> where K : BaseClass<T, K>, new()
    {
        T Value { get; set; }
        string Name { get; set; }
        public static K Factory(T value)
        {
            return new K { Value = value };
        }
    }
    class ChildClass : BaseClass<int, ChildClass>
    {
        public void Test()
        {
            ChildClass cs = Factory(10);
        }
    }
