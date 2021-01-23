    public string CombinedTeams                      
    {                      
        get                      
        {                                         
            return Combined;                      
        }                      
        ...
    }           
    private string Combined                        
    {                        
        get                        
        {                        
            return " " + HomeTeam + " " + HomeScore + " - " + AwayScore + " " + AwayTeam;                        
        }
        ...
    }
