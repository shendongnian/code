    public static IEnumerable GetAccounts()
    {
        var myEnum = Enumerable.Range(0, 10).Select(x => new { Id = x, Name = "herbert" });
        return myEnum;
    }
    foreach (dynamic account in GetAccounts())
    {
        Console.WriteLine(string.Format("Id: {0}, Name: {1}", account.Id, account.Name));
    }
