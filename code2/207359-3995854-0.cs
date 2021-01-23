    public class Foo { public int Hello(string s) { return 10; } }
    
    void Test()
    {
        Func<Foo, Func<string, int>> a = foo => foo.Hello;
    }
