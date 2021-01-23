    public static List<List<Tuple<string, string>>> ListMatches(List<string> listTeam)
    {
        var result = new List<List<Tuple<string, string>>>();
    
        int numDays = (listTeam.Count - 1);
        int halfSize = listTeam.Count / 2;
        var teams = new List<string>();
        teams.AddRange(listTeam.Skip(halfSize).Take(halfSize));
        teams.AddRange(listTeam.Skip(1).Take(halfSize - 1).ToArray().Reverse());
        int teamsSize = teams.Count;
    
        for (int day = 0; day < numDays; day++)
        {
            var round = new List<Tuple<string, string>>();
            int teamIdx = day % teamsSize;
            round.Add(new Tuple<string, string>(teams[teamIdx], listTeam[0]));
    
            for (int idx = 1; idx < halfSize; idx++)
            {
                int firstTeam = (day + idx) % teamsSize;
                int secondTeam = (day + teamsSize - idx) % teamsSize;
    
                round.Add(new Tuple<string, string>(teams[firstTeam], teams[secondTeam]));
            }
            result.Add(round);
        }
        return result;
    }
