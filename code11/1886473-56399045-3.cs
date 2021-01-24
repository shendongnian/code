    class Program
    {
        static void Main(string[] args)
        {
            int number1;
            int number2;
            int result;
            Console.Write("Enter a number: ");
            number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter a second number: ");
            number2 = int.Parse(Console.ReadLine());
            result = number1 * number2;
            Console.WriteLine($"The total is: {result} ");
            Console.WriteLine("AND");
   
            Calculations calc = new Calculations();
            calc.CheckEvenOrOdd(result);
            Console.ReadLine();
         }
    }
    public class Calculations
    {
        public void CheckEvenOrOdd(int numb)
        {
            if (numb % 2 == 0)
            {
                Console.WriteLine("The number is even");
            }
            else
            {
                Console.WriteLine("The number is odd ");
            }
        }
    }
