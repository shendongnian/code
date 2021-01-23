    public interface ISomething { string Name { get; set; } }
    public class SomethingA : ISomething { public string Name { get; set; } = nameof(SomethingA); }
    public class SomethingB : ISomething { public string Name { get; set; } = nameof(SomethingB); }
    void MyMethod<T>(params T[] somethings) where T : ISomething
    {
        foreach (var something in somethings)
        {
            if (something != null)
                Console.WriteLine(something);
        }
    }
    // Use it!
    ISomething a = new SomethingA();
    ISomething b = new SomethingB();
    // You don't need to specify the type in this call since it can determine it itself.
    MyMethod(a, b);
    // If calling it like this though you do:
    MyMethod<ISomething>(new SomethingA(), new SomethingB());
