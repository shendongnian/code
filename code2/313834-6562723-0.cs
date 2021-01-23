    public class Parent
    {
        protected Int64 MyCounter{ get; set; }
    }
    
    public class Child : Parent
    {
        protected string ClassName 
       { 
            get 
            {
                return "Child";
            }
        }
    }
    
    public class Runner
    {
        static void Main(string[] args)
        {
            var c = new Child();
            c.Counter++;
    
            Console.WriteLIne(c.Counter);
        }
    }
