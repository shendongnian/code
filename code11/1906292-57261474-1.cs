    private static void Main()
    {
        double answer;
        double answer1;
        bool Continue = true;
        Console.WriteLine("\tCalculator");
        Console.WriteLine("--------------------------\n");
        Console.WriteLine("   Math Operations: ");
        Console.WriteLine(" --------------------");
        Console.WriteLine("  Multiplication: *");
        Console.WriteLine("        Addition: +");
        Console.WriteLine("     Subtraction: -");
        Console.WriteLine("        Division: /");
            
        while (Continue)
        {
            Console.WriteLine("\nEnter your equation below:");
            Console.WriteLine("For example: 5 + 5 ");
            string[] values = Console.ReadLine().Split(' ');
            double firstNum = double.Parse(values[0]);
            string operation = (values[1]);
            double secondNum = double.Parse(values[2]);
            if (operation == "*")
            {
                answer = firstNum * secondNum;
                Console.WriteLine("\n" + firstNum + " * " + secondNum + " = " + answer);
            }
            else if (operation == "/")
            {
                answer = firstNum / secondNum;
                Console.WriteLine("\n" + firstNum + " / " + secondNum + " = " + answer);
            }
            else if (operation == "+")
            {
                answer = firstNum + secondNum;
                Console.WriteLine("\n" + firstNum + " + " + secondNum + " = " + answer);
            }
            else if (operation == "-")
            {
                answer = firstNum - secondNum;
                Console.WriteLine("\n" + firstNum + " - " + secondNum + " = " + answer);
            }
            else
            {
                Console.WriteLine("Sorry that is not correct format! Please restart!");
            }
            Console.WriteLine("\n\nDo you want to continue?");
            Console.WriteLine("Type in Yes or No:");
            string response = Console.ReadLine();
            if (response != "Yes") Continue = false;
        }
    }
