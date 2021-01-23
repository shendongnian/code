        System.Console.Write("Please enter the first number: ");
        string first = System.Console.ReadLine();
        input = Convert.ToInt32(first);
        System.Console.WriteLine();
        System.Console.Write("Please enter the second number: ");
        string second = System.Console.ReadLine(); //Doesn't wasit for input and sets input1 = 13
        input1 = Convert.ToInt32(second);
        System.Console.WriteLine();
        output = input * input1;
        System.Console.WriteLine();
        System.Console.Write("{0} times {1} equals {2}.", input, input1, output);
        System.Console.ReadKey();
