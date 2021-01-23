    class Player
    {
        private Screen parentScreen;
    
        public Player(Screen parentScreen) { this.parentScreen = parentScreen; }
    
        public MyMethodThatHasToCallScreensMethod()
        {
            parentScreen.ResetHUD();
        }
    }
    class Screen
    {
        public Player CreatePlayer()
        {
            return new Player(this);
        }
    }
