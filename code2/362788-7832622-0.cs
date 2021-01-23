    using (Model m = new Model())
    {
        var result = from attack in m.Attacks
                     group attack by attack.Player into attacksForPlayer
                     select new
                     {
                         PlayerName = attacksForPlayer.Key.Name,
                         NumberOfAttacks = attacksForPlayer.Count(),
                         NumberOfKills = (from k in m.Kills
                                          where attacksForPlayer.Contains(k.Attack)
                                          select k).Count()
                     };
    
        // This result can be read like this:
        foreach (var r in result)
        {
            // r.PlayerName, r.NumberOfAttacks, r.NumberOfKills
        }
    }
