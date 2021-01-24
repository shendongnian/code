    bool Ustop = false;
    while (!Ustop)
    {
        for (var i = 0; i< UserList.Count ; i++ )
        {
            User u = UserList[i];
            if (ruser == u.CName)
            {
                Console.WriteLine("Please key in the existing password of the selected username");
                string epass = Console.ReadLine();
    
                if (epass == u.CPassword)
                {
                    Console.WriteLine("Create new Administrator Username:");
                    NCName = Console.ReadLine();
    
                    Console.WriteLine("\nCreate new Administrator Password: ");
                    NCPassword = Console.ReadLine();
    
    
                    u.CName = NCName;
                    u.CPassword = NCPassword;
                }
                else
                {
                    Console.WriteLine("Password that you key in is invalid!");
                }
            }
            else
            {
                Console.WriteLine("Username that you key in did not exist!");
                Console.WriteLine("Please key in a valid username");
            }
        }
    }
