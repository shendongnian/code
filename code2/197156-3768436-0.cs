    public class Foo
    {
       static Foo()
       { 
          Console.WriteLine("called first time only");
       }
       public Foo()
       {
          Console.WriteLine("called every new object"); 
       }
    }
