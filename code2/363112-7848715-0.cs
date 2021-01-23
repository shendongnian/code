    private static IEnumerable<Tuple<T, T>> GetGames<T>(IEnumerable<T> players)
    {
        var matches = (players.SelectMany((player1, index) =>
            players.Skip(index + 1)
            .Select(player2 => new Tuple<T, T>(player1, player2))))
            .ToList();
        while (matches.Any())
        {
            var first = matches.First();
            matches.Remove(first);
            var second = matches.First(i => 
                !i.Item1.Equals(first.Item1) && 
                !i.Item1.Equals(first.Item2) && 
                !i.Item2.Equals(first.Item1) && 
                !i.Item2.Equals(first.Item2));
            matches.Remove(second);
            yield return first;
            yield return second;
        }
    }
