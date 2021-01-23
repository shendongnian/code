    class multiplythisnumber
    {
        static void Main()
        {
        int input, input1, output; //variable decleration
        System.Console.WriteLine("This application is meant to multiply two single digit numbers.");
        System.Console.WriteLine("You can choose both numbers, however this is only a test.\r I am not sure the read command even does what I think it does.");
        System.Console.WriteLine();
    
        System.Console.Write("Please enter the first number: ");
        input = Int32.Parse(System.Console.Read());
        //input = input - 48;//No need to do this anymore as we have already converted the user's input to an integer.
        System.Console.WriteLine();
    
        System.Console.Write("Please enter the second number: ");
        input1 = Int32.Parse(System.Console.ReadLine());
        System.Console.WriteLine();
        output = input * input1;
        System.Console.WriteLine();
        System.Console.Write("{0} times {1} equals {2}.", input, input1, output);
        System.Console.ReadKey();
        }
    }
