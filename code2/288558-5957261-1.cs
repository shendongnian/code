    public class Something
    {
        void DoSomething(int? value);
        void DoSomething(string value);
    }
    // ...
    new Something().DoSomething(null); // I believe this is ambiguous...
    const string value = null;
    new Something().DoSomething(value); // Not ambiguous
