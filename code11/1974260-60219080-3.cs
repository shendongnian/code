    public class Bar 
    {
         public Bar(int foo) => Foo = foo;
         public int Foo {get;set;}
         public void WriteLine() => Console.WriteLine(Foo);
         ...
