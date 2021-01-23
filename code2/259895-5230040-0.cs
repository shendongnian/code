    public enum GameType { Basketball, Snooker, ... }
    
    void BindGameData(GameType gameType)
    {
    [ sql connection code ]
    StringBuilder sb = new StringBuilder();
    // those constant parts should be stored outside in config file
    sb.append("SELECT * FROM aspnet_GameProfiles INNER JOIN aspnet_Games ON aspnet_GameProfiles.GameId = aspnet_Games.GameId "); 
    sb.append("INNER JOIN ");
    sb.append("aspnet_" + gameType.toString()); // adopt to yours naming pattern
    sb.append("ON aspnet_Games.GameId = ");
    sb.append("aspnet_" + gameType.toString() + ".GameId");
    sb.append("WHERE UserId = @UserId");
    
    String selectSql = sb.toString();
    
    [rest of yours sql connection code]
    
    }
