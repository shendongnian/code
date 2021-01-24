    public static bool Login()
    {
        string sUsername;
        string sPassword;
        string check;
        int nPick;
        bool UserExists = false;
    
        Console.WriteLine("Insert username: ");
        sUsername = Console.ReadLine();
        Console.WriteLine("Insert password: ");
        sPassword = Console.ReadLine();
    
        List<User> lUser = GetUsers();
        for (int i = 0; i < lUser.Count(); i++)
        {
            if (lUser[i].username == sUsername && lUser[i].password == sPassword)
            {
                UserExists = true;
                Console.WriteLine("\n Login successfull!");
                do
                {
                    Menu();
                    check = Console.ReadLine();
                    int.TryParse(check, out nPick);
                    switch (nPick)
                    {
                        case 1:
    
                            break;
                        case 2:
    
                            break;
                        case 3:
    
                            break;
                        case 4:
    
                            break;
                        case 5:
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\n Option not existing!");
                            break;
                    }
                }
                while (nPick != 5);
            }
        }
        if (!UserExists) {
            Console.WriteLine("\n Wrong username or password!\n");
        }
        return UserExists; 
    } 
