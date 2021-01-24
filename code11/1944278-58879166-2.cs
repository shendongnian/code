    public Team(IEnumerable<string> playerNames){
        Name = string.Empty;
        Players = new List<Player>();
        foreach(var player in playerNames {
            Players.Add(new Player { Name = player});
       };
    }
