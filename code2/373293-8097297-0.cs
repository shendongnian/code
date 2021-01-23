    class Program
    {
       delegate void Foo();
    
       static void Main(string[] args)
       {
          Foo myDelegate = One;
          myDelegate += Two;
    
          myDelegate();
       }
    
       static void One()
       {
          Console.WriteLine("In one..");
       }
    
       static void Two()
       {
          Console.WriteLine("In two..");
       }
    }
