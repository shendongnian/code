    public class Bar 
    {
         public Bar(int foo) => Foo = foo;
         public readonly int Foo {get;set;}
         public void WriteLine() => Console.WriteLine(_foo);
         ...
