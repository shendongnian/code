    Console.WriteLine("You only need to pay " + sodaprice + " cents");
    // To force to start the loop, we ask the value inside the loop
    double coin = 1d;
    // We should reach zero or less starting from the initial price (minus lottery)  
    double amountDue = sodaprice;
    while (coin > 0)
    {
        Console.WriteLine("Please insert a coin of 5, 10, or 25:");
        string coininput = Console.ReadLine();
        // use tryparse when trying to convert user input in numbers.
        // tryparse returns true if the input is a number without raising exceptions
        if(double.TryParse(coininput, out coin))
        {
           // Decrement the amount to pay with the user input
           amountDue -= coin;
 
           // Decide for a message and continue the loop or stop 
            if(amountDue > 0)
                Console.WriteLine("You still owe " + amountDue + " cents.");
            else
                break;
        }
    }
