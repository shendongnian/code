    public static IEnumerable<Round> CreateRandomMatches(List<Team> teams)
    {
        var random = new Random();
        var randomTeams = teams.OrderBy(t => random.Next()).ToList();
        for (int i = 1; i < teams.Count; i += 2)
        {
            yield return new Round
            {
                Team1 = randomTeams[i - 1].Name,
                Team2 = randomTeams[i].Name
            };
        }
    }
