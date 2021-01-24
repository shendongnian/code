    if(team != null)
    {
        TeamSession newTeamSession = new TeamSession()
        {
            Team = team,                            
            LeagueSessionSchedule = leagueSessionSchedule
        };
        leagueSessionSchedule.TeamsSessions.Add(newTeamSession);
    }
