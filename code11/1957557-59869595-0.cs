public class Foo
{
    public Foo()
    {
        // Left empty intentionally
    }
    public static Foo Create(Type1 a, Type2 b) { ... }
    public static Foo Create(Type2 a, Type3 b) { ... }
    public static Foo Create(Type4 a, Type5 b) { ... }
}
This is a bit hacky, but this at least fixes the issue.
