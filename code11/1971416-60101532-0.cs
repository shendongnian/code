    public class EPlayers
    {
        public int team;
        public EPlayers(){}
        internal EPlayers(int selectedTeam)
        {
            this.team = selectedTeam;                
        }
    }        
    
    void Loaded()
    {
        LoadData();
        ePlayers.Add(player.userID, new EPlayers(SelectTeam()){});                    
        SaveData();             
    }
