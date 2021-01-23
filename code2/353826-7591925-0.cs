    class Program
    {
        static void Main(string[] args)
        {
            int input, input1; 
            string output; //variable decleration
            System.Console.WriteLine("This application is meant to multiply two single digit numbers.");
            System.Console.WriteLine("You can choose both numbers, however this is only a test.\r I am not sure the read command even does what I think it does.");
            System.Console.WriteLine();
            System.Console.Write("Please enter the first number: ");
            int.TryParse(System.Console.ReadLine(),out input); //Reads my input + 48(assuming 48 is the value of enter)
            
            System.Console.WriteLine();
            System.Console.Write("Please enter the second number: ");
            int.TryParse(System.Console.ReadLine(), out input1); //Doesn't wasit for input and sets input1 = 13
            System.Console.WriteLine();
            if (input != 0 && input1 != 0) {
                input = input - 48;
                output = (input * input1).ToString();
            }else
            {
                output = "NaN";//not a number
            }
            System.Console.WriteLine();
            System.Console.Write("{0} times {1} equals {2}.", input, input1, output);
            System.Console.ReadKey();
        }
    }
