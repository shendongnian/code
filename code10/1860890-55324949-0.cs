    interface IReadOnlyFoo
    {
        string Value { get;  }
    }
    interface IReadWriteFoo
    {
        string Value { get; set; }
    }
    class BasicFoo : IFoo, IReadOnlyFoo
    {
        public string Value { get; set; }
    }
