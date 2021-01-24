    class Program
    {
        static void Main(string[] args)
        {
            //string lb, kg;
            //string userInput = "";
            Console.Write("Enter either lb or kg:");
            string input = Console.ReadLine();
            string unit = input.Substring(input.Length-2);
            if (unit == "lb") // where the error occurs
            {
                int k = ConvertNumber();
                Console.WriteLine(k + "kg");
                //k.ConvertLb();
            }
            else if (unit == "kg")
            {
                int l = ConvertNumber();
                Console.WriteLine(l + "lb");
                //l.ConvertKg();
            }
            else
            {
                Console.WriteLine("invalid unit");
            }
            Console.ReadLine();
        }
        static int ConvertNumber()
        {
            Console.WriteLine("convert");
            return 123;
        }
    }
