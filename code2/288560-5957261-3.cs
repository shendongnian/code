    public class Something
    {
        public void DoSomething(int? value) { Console.WriteLine("int?"); }
        public void DoSomething(string value) { Console.WriteLine("string"); }
    }
    // ...
    new Something().DoSomething(null); // This is ambiguous, and won't compile
    const string value = null;
    new Something().DoSomething(value); // Not ambiguous
