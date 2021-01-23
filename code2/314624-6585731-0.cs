    List<Team> teams = context.Teams.ToList();
    var team = teams.FirstOrDefault(t => t.Name == newTeam.Name);
    if (team == null) 
    {
        context.Teams.AddObject(newTeam);
        teams.Add(newTeam);
    }
    context.SaveChanges();
