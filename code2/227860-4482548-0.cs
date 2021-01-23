    class Greeter
    {
       public string prefix { get; set; }
    
       public string greet(string who)
       {
          return prefix + " " + who;
       }
    }
    
    class Program
    {
       public static void doit(Func<string, string> a)
       {
          Console.Out.WriteLine(a("World"));
       }
    
       static void Main(string[] args)
       {
          // pass doit a Greeter method bound to instance foo
          Greeter foo = new Greeter() { prefix = "Hello" };
          doit(foo.greet);
          
          // pass doit a Greeter method bound to instance bar
          Greeter bar = new Greeter() { prefix = "Bonjour" };
          doit(bar.greet);
    
          // pass doit a closure bound to the local variable prefix
          string prefix = "Goodbye";
          doit(( who) => prefix + " " + who );
       }
    }
