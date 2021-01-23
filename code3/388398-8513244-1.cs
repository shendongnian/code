       public class PlayersManager
       {
         private readonly Player[,] _players;
         private readonly int _totalNumberOfPlayers;
         private readonly int _topNumberOfTeams;
         private bool PlayerPositionReachedLimit {
            get { return _playerPosition == _topNumberOfTeams; }
         }
         private bool PlayerCounterExcedsTotalPlayers
         {
            get { return _playerCounter >= _totalNumberOfPlayers; }
         }
         private int _playerCounter;
         private int _playerPosition;
      
        public Player[,] Players
        {
            get { return _players; }
        }
        public PlayersManager(int totalNumberOfPlayers, int topNumberOfTeams)
        {
            _playerCounter = 0;
            _playerPosition = 0;
            _topNumberOfTeams = topNumberOfTeams;
            _totalNumberOfPlayers = totalNumberOfPlayers;
            _players = new Player[totalNumberOfPlayers, topNumberOfTeams];
        }
       
        public void Add(Player player)
        {
            if (PlayerCounterExcedsTotalPlayers)
              throw new Exception("Number of players exceded");
            if (PlayerPositionReachedLimit)
            {
                _playerCounter++;
                _playerPosition = 0;
            }
            _players[_playerCounter, _playerPosition]= player;
            
            _playerPosition++;
        }
    }
