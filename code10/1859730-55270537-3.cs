    List<MySite> mySites = new List<MySite>();
    mySites.Add(new MySite() { Name = "site1", Path = @"c:\a.pdf" });
    mySites.Add(new MySite() { Name = "site2", Path = @"c:\b.pdf" });
    mySites.Add(new MySite() { Name = "site3", Path = @"C:\c.pdf" });
    
    int choice = ChooseListBoxItem(mySites.Select(s=>s.Name).ToArray(), 34, 3,
        ConsoleColor.DarkGreen, ConsoleColor.White);
    
    WriteColorString("You chose " + mySites[choice - 1].Name + ".", 25, 22, 
        ConsoleColor.Black, ConsoleColor.White);
    Process.Start(mySites[choice - 1].Path);
