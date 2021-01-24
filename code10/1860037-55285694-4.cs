    using System;
    using System.Linq;
    using System.Collections.Generic;
    public static IEnumerable<Player> GetGroupedPlayers(IEnumerable<Player> players)
    {
        return players
        .OrderByDescending(player => player.Points)
        .Select((player, index) =>
        new
        {
            Player = player,
            Rank = ++index
        })
        .GroupBy(container => container.Player.Points)
        .Select(group =>
        {
            var firstPlayer = group.First().Player;
            var groupMin = group.Min(container => container.Rank);
            var groupMax = group.Max(container => container.Rank);
            firstPlayer.Rank = groupMin == groupMax ? $"{groupMin}." : $"{groupMin} - {groupMax}.";
            return group.Select(g => g.Player);
        })
        .SelectMany(player => player);
    }
