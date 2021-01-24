    public IEnumerable<Team> GetTeams() => dbConnection.Query<Team, Supervisor, Location, Team>(query, (team, supervisor, location, team) => 
    {
       team.Supervisor = supervisor,
       team.Location = location,
       return team;  
    });
