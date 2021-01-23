    public static void Main(string[] args)
    {
       PrintChoices();
    }
    
    private static void PrintChoices()
    {
        string userChoice = Console.ReadLine();
     
        if (userChoice == "y")
            PrintChoices();        
    }
