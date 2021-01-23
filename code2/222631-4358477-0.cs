    using System.Runtime.InteropServices;
    struct Foo {
        byte a, b, c;
    }
    static class Program {
        unsafe static void Main() {
            int i = sizeof(Foo); // <==== 3
        }
    }
