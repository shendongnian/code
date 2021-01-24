    double result;
    for(; ; )
    {
        Console.WriteLine("Type in a number and then press enter:");
    
        if(!double.TryParse(Console.ReadLine(), out result)){
            Console.WriteLine("Please Enter a valid numerical value!");
            Console.WriteLine("Please enter a valid number and then press enter:");
        }
        else
        {
            break;
        }
    }
    Console.WriteLine($"Result = {result}");
