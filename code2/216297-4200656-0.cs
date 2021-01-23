    var beerCounts = from vote in votes
                     where vote.BeerID != null
                     group vote by vote.BeerID into beerVoteGroups
                     select new
                     {
                         Count = beerVoteGroups.Count(),
                         BeerID = beerVoteGroups.Key
                     };
    foreach (var group in beerCounts)
    {
        Console.WriteLine("Beer {0} got {1} votes", group.BeerID, group.Count);
    }
