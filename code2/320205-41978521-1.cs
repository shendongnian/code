    namespace Exception
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool isNumeric;
                int n;
                do
                {
                    Console.Write("Enter a number:");
                    isNumeric = int.TryParse(Console.ReadLine(), out n);
                } while (isNumeric == false);
                Console.WriteLine("Thanks for entering number" + n);
                Console.Read();
            }
        }
    }
