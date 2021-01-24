    Console.WriteLine("Please enter your gender.");    
    do
    {
                Console.WriteLine("What is you gender?");
                gender = Console.ReadLine().ToLower();
    }
    while (gender != "male" && gender != "female" && gender != "others");
    
