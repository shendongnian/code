    bool isRedTeam = true; // true/false
    
    ObservableCollection<string> ListOfRedPlayers { get; set; }
    ObservableCollection<string> ListOfBluePlayers { get; set; }
    
    public ObservableCollection<string> ListOfPlayers
    {
        get
        {
            if(isRedTeam) return ListOfRedPlayers
            else return ListOfBluePlayers
        }
        set
        {
            if (isRedTeam) ListOfRedPlayers = value;
            else ListOfBluePlayers = value;
        }
    }
