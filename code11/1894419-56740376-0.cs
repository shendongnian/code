    class Program
    {
        static void Main()
        {
            Animal a = new Dog("Hello World");
            Dog d = a as Dog;
    
            if (d == null)
                Console.WriteLine("Cast failed.");
            else
                Console.WriteLine(d.Greet());
        }
    }
