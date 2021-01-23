    // This store all of the checks formed as Fun<Player, bool> delegates.
    var checks = new List<Func<Player, bool>>();
    checks.Add(x => DoesPlayerSatisfyCheck1(x));
    checks.Add(x => DoesPlayerSatisfyCheck2(x));
    checks.Add(x => DoesPlayerSatisfyCheck3(x));
    // Add more checks here if necessary.
    
    // This stores all players who have passed a check.
    // The first check that passed will be associated with that player.
    var results = new Dictionary<Player, int>();
    
    // Loop through all players.
    foreach (Player p in participants)
    {
      // Now perform each test in order.
      for (int i = 0; i < checks.Count; i++)
      {
        Func<Player, bool> checker = checks[i];
        if (checker(p))
        {
          results.Add(p, i);
          break;
        }
      }
    }
