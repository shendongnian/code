    class Player : IInitialize
    {
      public Player(IGameEngine gameEngine)
      {
        gameEngine.Starting += InitializeOnGameStarting;
      }
    
      private void InitializeOnGameStarting(object sender, EventArgs e)
      {
        gameEngine.Starting -= InitializeOnGameStarting;
            
        // Invoke the implemented member of IInitialize
        Initialize();
      }
    }
