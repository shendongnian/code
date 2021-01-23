    namespace csfunction
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("The answer: " + AddNumbers(40, 2));
            }
            public static int AddNumbers(int number1, int number2)
            {
                int result = number1 + number2;
                return result;
            }
        } 
    }
