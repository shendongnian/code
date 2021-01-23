    string input = string.Empty;
    
    while(input.Equals("exit", StringComparison.CurrentCultureIgnoreCase)
    {
        input = Console.ReadKey();
        switch(input)
        {
        case "+":
            // speeds up the simulation by decreasing the delayTime
            IncreaseSpeed();
            break;
        case "-":
            // slows down the simulation by decreasing the delayTime
            DecreaseSpeed();
            break;
        default:
            break;
        }
    }
