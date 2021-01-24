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
As long as you are using implicit implementations for the interfaces it would behave as you intended. on the other hand, if you wish to have two different behaviors for the members of the interface then you want to use explicit implementations. You can find an example here  
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/how-to-explicitly-implement-members-of-two-interfaces
