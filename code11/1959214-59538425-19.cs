    context.Teams.Attach(team);
    context.LeagueSessionSchedules.Attach(leagueSessionSchedule);
    TeamSession newTeamSession = new TeamSession()
    {
        Team = team,                            
        LeagueSessionSchedule = leagueSessionSchedule
    }
