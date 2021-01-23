    class Program
    {
        static void Main()
        {
        
            List<string> list = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please enter a number");
                list.Add(Console.ReadLine()); // HERE !!
            }
        }
    }
