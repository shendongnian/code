    interface IReadOnlyFoo
    {
        string Value { get;  }
    }
    interface IFoo : IReadOnlyFoo
    {
        string Value { get; set; }
    }
    class BasicFoo : IFoo
    {
        public string Value { get; set; }
    }
