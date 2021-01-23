    class Program
    {
        static string firstline; # with static you can compile and got your behaviour
        static void Main(string[] args)
        {
          
            if (firstline == null)
            {
                System.Console.WriteLine("String empty!");
            }
            Console.ReadKey();
        }
    }
