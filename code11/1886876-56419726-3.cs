    public async Task<bool> AddPlayerRecord(PlayerStatRecord record)
    {
       // ToDo: Verify the current logged in session is active, and that the logged in 
       // user can modify the provided Player ID.
       
       // Look up the player by ID. Throws ex. if player not found.
       var player = _context.Players
           .Include(x => x.PlayerStats)
           .Single(x => x.PlayerId == record.PlayerId);
       // Look up any related information.
       var statistic = _context.Statistics.Single(x => x.StatisticId = record.StatisticId);
       // Validate any data that was provided to ensure it was complete.
       if(!record.IsComplete)
          Throw new ArgumentException("The provided player statistic was not valid.");
       
       // Populate a new player statistic entity, associate our references, and add it to 
       // the applicable player record.
       player.PlayeerStats.Add(new PlayerStatRecord 
       { 
          Statistic = statistic,
          // copy over other values and references...
       });
       var result = await _context.SaveChangesAsync();
       return result == 1;
    }
