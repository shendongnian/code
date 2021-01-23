    partial class Foo {
        partial void Bar() {
            Console.WriteLine("I can only be called from inside the type; "
               + "I can't be public");
        }
    }
