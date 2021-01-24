    public static void Main()
    {
        //VARIABLES
        int userNumber;//uN
        int searchedNumber = 87;
        int min = 1;
        int max = 100;
    
        //TASK FOR "CUSTOMER"
        Console.WriteLine($"Type in a number between {min}-{max}!");
    
        //DO-WHILE, because it hast to run one either way
        do
        {
            //READING OUT CONSOLE
            string userNumberString = Console.ReadLine();
            //CONVERTING STRING TO INT
            if (int.TryParse(userNumberString, out userNumber))
            {
                if (userNumber >= min && userNumber <= max)
                {
                    if (userNumber == searchedNumber)
                    {
                        Console.WriteLine("JACKPOT!");
                    }
                    else
                    {
                        Console.WriteLine("To " + (userNumber < searchedNumber ? "Low" : "High") + "! Try again.");
                    }
                }
                else
                {
                    Console.WriteLine($"Between {min} and {max}, Dummy!");
                }
            }
            else
            {
                Console.WriteLine($"One integer number, Dummy!");
            }
    
        } while (userNumber != searchedNumber);
    }
