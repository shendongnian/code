    class Program
    {
        static void Main()
        {
            int i = 0;
            var x = new Whatever<int>(()=>i);
            Console.WriteLine(x);
            i = 1;
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
    class Whatever<T>
    {
       private Func<T> variable;
       public Whatever(Func<T> func)
       {
           this.variable= func;
       }
       public override string ToString()
       {
           return this.variable().ToString();
       }
    }
