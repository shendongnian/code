    class App
    {
      
        static void Main(string[] args)
        {
    
            Foo foo = new Foo(delegate(string n) {
                                Console.WriteLine(n);
                                return true; //this is it unnecessary, you can use the `void` type instead.          });
            Console.ReadLine();
        }
    }
