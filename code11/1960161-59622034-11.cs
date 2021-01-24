    public static SecureString GetPasswordAsSecureString(string prompt)
    {
        SecureString pwd = new SecureString();
        ConsoleKeyInfo key;
        Console.Write(prompt + @": ");
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                pwd.AppendChar(key.KeyChar);
                Console.Write("*");
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && pwd.Length != 0)
                {
                    pwd.RemoveAt(pwd.Length - 1);
                    Console.Write("\b \b");
                }
            }
        }
        while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        return pwd;
    }
    var impPassword = GetPasswordAsSecureString($"Enter the password for {impUser}");
