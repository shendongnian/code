    switch (Note)
    {
        case 1:
        case 2:
        case 3:
        case 4:
            Console.WriteLine("Passed");
            break;
        case 5:
        case 6:
            Console.WriteLine("Failed");
            break;
        default:
            Console.WriteLine("Your input is wrong!");
            break;
    }
