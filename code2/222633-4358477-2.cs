    struct Foo {
        byte a, b, c;
    }
    static class Program {
        unsafe static void Main() {
            int i = sizeof(Foo); // <==== i=3
        }
    }
