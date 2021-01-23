    interface IName<T>
    {
        T Name { get; set; }
    }
    class Person : IName<string>
    {
        public string Name { get; set; }
    }
