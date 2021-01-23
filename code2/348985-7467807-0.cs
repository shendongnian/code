    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(Foo.Everything.HasFlag(Foo.None)); // False
            Console.WriteLine(Foo.Everything.HasFlag(Foo.Baz)); // True
            Console.WriteLine(Foo.Everything.HasFlag(Foo.Hello)); // True
        }
    }
    [Flags]
    public enum Foo : uint
    {
        None = 1 << 0,
        Bar = 1 << 1,
        Baz = 1 << 2,
        Qux = 1 << 3,
        Hello = 1 << 4,
        World = 1 << 5,
        Everything = Bar | Baz | Qux | Hello | World
    }
