csharp
private static void LoginMenu()
{
    Console.SetCursorPosition(10, 7);
    Console.Write("Username: ");
    username = Console.ReadLine();
    Console.SetCursorPosition(10, 8);
    Console.Write("Password: ");
    password = Console.ReadLine();
    
    bool loginSuccessful = false;
    using (StreamReader sr = new StreamReader(File.Open(textFile, FileMode.Open)))
    {
        string line;
        // Read one line at a time from file until end of file.
        while((line = sr.ReadLine()) != null)  
        {
            // split the line by comma.
            var creds = line.Split(',');
            // if the values match, set login to true and exit the while loop.  
            if (username == creds[0] && password == creds[1])
            {
                loginSuccessful = true;
                break;
            }
        }
        sr.Close();
    }
    if(loginSuccessful)
    {
        Console.WriteLine("Login Successful! Press any key to continue...");
        Console.SetCursorPosition(57, 13);
        Console.Clear();
        GoToMainMenu();
    }
    else {
        Console.WriteLine("Username or password is incorrect. Try again");
        Console.ReadKey();
        Console.Clear();
        LoginMenu();
    }
    Console.Read();
}
