    public static IEnumerable<Match> CreateRandomMatches(List<Team> teams)
    {
        var random = new Random();
        var randomTeams = teams.OrderBy(t => random.Next()).ToList();
        for (int i = 1; i < teams.Count; i += 2)
        {
            yield return new Match
            {
                Team1 = randomTeams[i - 1].Name,
                Team2 = randomTeams[i].Name
            };
        }
    }
