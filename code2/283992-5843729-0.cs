    public string Format 
    {
        get
        {
            if(LastManStanding)
                return string.Format("FFA {0}v{0}", m_Teams.PlayersPerTeam);
            else
                return string.Format("{0}v{0}", m_Teams.PlayersPerTeam);
        }
    }
