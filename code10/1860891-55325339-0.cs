csharp
    interface IReadOnlyFoo
    {
        string Value { get; }
    }
    interface IFoo : IReadOnlyFoo
    {
        new string Value { set; }
    }
    class BasicFoo : IFoo
    {
       public string Value { get;  set; }
    }
