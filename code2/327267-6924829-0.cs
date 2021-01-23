    class Program
    {
        static void Main(string[] args)
        {
            dynamic d = new object();
            var x = (Program)d;
            Console.WriteLine(x);
            var y = d as Program;
            Console.WriteLine(y);
            
            var z = d is Program;
            Console.WriteLine(z);
        }
    }
