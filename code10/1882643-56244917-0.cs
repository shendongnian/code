        List<string> list = new List<string>() { "Bob", "Michael", "Adrian", "Daniel", "Denzel", "Peter" }; //etc
        var milist = list.OrderBy(f => Guid.NewGuid()).Distinct().ToList();
        string firstTeam = "";
        foreach (var item in milist.Take(list.Count() / 2))
        {
            firstTeam += item + ", ";
        }
        firstTeam = firstTeam.Substring(0, firstTeam.Length - 2);
        string secondTeam = "";
        foreach (var item in milist.Skip(list.Count() / 2))
        {
            secondTeam += item + ", ";
        }
        secondTeam = secondTeam.Substring(0, secondTeam.Length - 2);
        Console.WriteLine(firstTeam + " vs " + secondTeam);
        Console.ReadKey();
