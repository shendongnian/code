    IOrderedEnumerable<PlayerResult> OrderByWinsAndLosses(this IEnumerable<PlayerResult> playerResults)
    {
        return playerResults.OrderByDescending(playerResult => playerResult.Wins)
                            .ThenBy(playerResult => playerResult.Losses);
    }
