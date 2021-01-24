    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! What is your name?");
            string name = Console.ReadLine();
    
            Console.WriteLine(name + " What do you wanna do?");
            string[] operations = new string[] { "\"+\" for addition", "\"-\" for subtraction", "\"*\" for multiplication", "\"/\" for divsion" };
            foreach (string operation in operations) { Console.WriteLine("Type " + operation); }
    
            string cmd = Console.ReadLine();
    
            Console.Write("Now, Give me number one: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
    
            Console.Write("Now give me number two: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
    
            switch (cmd)
            {
                case "+": Console.WriteLine(num1 + num2); break;
                case "-": Console.WriteLine(num1 - num2); break;
                case "*": Console.WriteLine(num1 * num2); break;
                case "/": Console.WriteLine(num1 / num2); break;
            }
        }
    }
