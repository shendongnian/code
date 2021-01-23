    static void Main()
    {
        int input, input1, output; //variable decleration
    
        System.Console.WriteLine("This application is meant to multiply two single digit numbers.");
        System.Console.WriteLine("You can choose both numbers, however this is only a test.\r I am not sure the read command even does what I think it does.");
        System.Console.WriteLine();
    
        System.Console.Write("Please enter the first number: ");
        input = System.Console.Read(); //Reads my input + 48(assuming 48 is the value of enter)
    
        input = input - 48;
 
        /**
        *HINT: Try to use below double line:
        */   
        System.Console.Read();
        System.Console.Read();
    
        System.Console.Write("Please enter the second number: ");
        input1 = System.Console.Read(); //Doesn't wasit for input and sets input1 = 13
        System.Console.Read();
    
        output = input * input1;
    
        System.Console.WriteLine();
        System.Console.Write("{0} times {1} equals {2}.", input, input1, output);
    
        System.Console.ReadKey();
    }
