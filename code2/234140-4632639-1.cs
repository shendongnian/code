    public static IEnumerable GetAccounts()
    {
        return Enumerable.Range(0, 10)
               .Select(x => new { Id = x, Name = "herbert" });
    }
    //...
    foreach (dynamic account in GetAccounts())
    {
        Console.WriteLine(string.Format("Id: {0}, Name: {1}", 
                          account.Id, 
                          account.Name));
    }
