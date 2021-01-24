       class PlayerMgtUIHandler  : IPlayerMgtUIHandler 
        {
            public List<IPlayer> NewPlayers { get; protected set; } //TODO change List to HashSet
    
    
    
            public void AddNewPlayer(string idPrefix, string idSeparator, int idSeqNumber,int idNumDigits)
            {
                IPlayer player=new Player(idPrefix,idSeparator,idSeqNumber,idNumDigits);
                NewPlayers.Add(player);
            }
             
            public PlayerMgtUIHandler()
            {
                NewPlayers = new List<IPlayer>();
            }
    
        }
