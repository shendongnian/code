    static Boolean Login()
    {
        bool loginOK = false;
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Type username");
            String User = Console.ReadLine();
            Console.WriteLine("Type password");
            String Pass = Console.ReadLine();
            Console.Clear();
            if (User == "ad" && Pass == "min")
            {
                loginOK = true;
                hoofdMenu();
                break; // <------------- see her, you exit the loop
            }
        }
        return loginOk;
    }
        
