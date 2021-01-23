    var beerCounts = from vote in votes
                     where vote.BeerID != null
                     group vote by vote.BeerID into beerVoteGroups
                     let voteCount = beerVoteGroups.Count()
                     orderby voteCount descending 
                     select new
                     {
                         Count = voteCount,
                         BeerID = beerVoteGroups.Key
                     };
