    ```
    static (string Name, string Passw0rd) GetAccount()
    {
        string username = null;
        string passwd = null;
        Console.WriteLine("enter your name:");
        username = Console.ReadLine();
        Console.WriteLine("enter password:");
        passwd = Console.ReadLine();
     
        return( username, passwd );
    }
    ```
