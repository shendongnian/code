    // Now we have an array of friend (not misterious 2d array of strings)
    Vriend[] vriendenarray = new Vriend[vrienden];
    // We create friends
    for (int i = 0; i < vriendenarray.Length; ++i)
      vriendenarray[i] = new Vriend();
    for (int i = 0; i < vriendenarray.Length; ++i) {
      // Please, note how it's easy now: we assign Naam, not second index 0
      Console.Write("Vul hier de naam in van je vriend -->");
      vriendenarray[i].Naam = Console.ReadLine();  
      ...  
      Console.Write("Vul hier zijn/haar favourite dier in -->");
      vriendenarray[i].Dier = Console.ReadLine();
    }
    // for each vriend in vriendenarray is more readable
    foreach (var vriend in vriendenarray)
    {
        // String interpolation allows us to put code - vriend.Naaam - within string
        Console.WriteLine($"Vriend nummer {vriend.Naaam}...");
    } 
