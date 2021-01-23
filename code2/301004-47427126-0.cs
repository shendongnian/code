    class Program
    {
        static void Main(string[] args)
        {
            Service1 webService = new Service1();
            Console.WriteLine(webService.MyFirstWebMethod("Dhiraj”, “Kumar”));
            Console.ReadLine();
        }
    }
