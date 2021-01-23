    class Foo
    {
       int bar;
       void M()
       {
           Console.WriteLine(bar); // not an error, bar is 0;
           bool someBool;
           Console.WriteLine(someBool); // use of uninitialized local variable
       }
    }
