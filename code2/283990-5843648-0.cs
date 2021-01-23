    public string Format 
    { 
        get 
        { 
            return string.Format("{0}{1}v{1}", LastManStanding ? "FFA " : string.Empty,
                                               m_Teams.PlayersPerTeam); 
        } 
    }
