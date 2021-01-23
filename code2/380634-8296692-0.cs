    //Throws an error if more than one object has the same name.
    var beer = beers.Keys.Single(b => b.Name == beerName);
    
    beers[beer] = ...;
    // -or -
    //Selects the first of many objects that have the same name.
    //Exception if there aren't any matches.
    var beer = beers.Keys.First(b => b.Name == beerName);
    beers[beer] = ...;
    // -or -
    //Selects the first or default of many objects.
    var beer = beers.Keys.FirstOrDefault(b => b.Name == beerName);
    //You'll need to null check
    if (beer != null)
    {
        beers[beer] = ...;
    }
    // etc...
