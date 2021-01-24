    Console.Write("What Operation?: ");
    string input = Console.ReadLine();
    string op;
    switch (input)
    {  
        case "+":
            op = input;
            break;
        case "-":
            op = input;
            break;
        case "*":
            op = input;
            break;
        case "/":
            op = input;
            break;
        default:
            op = "Enter a valid operation!!!";
            Console.WriteLine(op);
            Console.ReadLine();
            break;
    }
