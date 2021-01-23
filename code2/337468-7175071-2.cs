    // Assembly A.dll
    public class Foo { public static const int X = 42; }
    // Assembly B.dll
    int y = Foo.x;
    // this is the equivalent to:
    int y = 42;
