    List<string> users = new List<string>();
    using (StreamReader r = new StreamReader("Users.txt"))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            users.Add(line);
        }
    }
    
    ...
    
    string user = Console.ReadLine();
    Out.WriteLine("Checking..");
    if (users.Contains(user))
    {
        Out.WriteLine("Username is taken");
    }
