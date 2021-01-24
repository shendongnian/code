    public static bool Method3(int userChoice)
    {
        if (userChoice == 1)
        {
            Console.WriteLine("do this");
            return false;
        }
        return true;
    }
    public static void Main(string[] args)
    {
        bool tryAgain;
        do
        {
            Method1();
            int userChoice = Method2();
            tryAgain = Method3(userChoice);
        } while (tryAgain);       
    }
