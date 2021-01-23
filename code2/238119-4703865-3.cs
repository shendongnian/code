    using System;
    
    class Foo {
        static object foo = new object();
        static void Main() {
            lock (foo) {
                foo = new object();
            }
    
        }
    }
