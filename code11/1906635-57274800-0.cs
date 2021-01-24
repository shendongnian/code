    // Your codes
    while (Continue)
    {
        Console.WriteLine("\nEnter your equation below:");
        Console.WriteLine("    For example: 5 + 5 ");
    
        string str = Console.ReadLine().Replace(" ", "");      // Remove all spaces
        string[] values = Regex.Split(str, @"([\+\-\*\/])");   // Split numbers and operator and also keep operator
    
        if (values.Length != 3)
        {
            Console.WriteLine("Expresion is not correct.");
        }
        else
        {
            double firstNum = double.Parse(values[0]);
            string operation = (values[1]);
            double secondNum = double.Parse(values[2]);
    
            switch (operation)
            {
                case "*":
                    answer = firstNum * secondNum;
                    break;
                case "/":
                    answer = firstNum / secondNum;
                    break;
                case "+":
                    answer = firstNum + secondNum;
                    break;
                case "-":
                    answer = firstNum - secondNum;
                    break;
                default:
                    Console.WriteLine("Sorry that is not correct format! Please restart!");
                    break;
            }
            Console.WriteLine($"{firstNum} {operation} {secondNum} = {answer}");
    
            Console.WriteLine("\n\nDo you want to continue?");
            Console.WriteLine("Type in Yes to continue or press any other key and then press enter to quit:");
            string response = Console.ReadLine();
            Continue = (response.ToUpper() == "YES" || response.ToUpper() == "Y");
        }
    }
    // Your codes
