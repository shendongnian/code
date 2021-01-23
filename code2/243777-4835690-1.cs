    public static class Control
    {
        //Change these to private
        private static Dictionary<PlayerIndex, GamePadState> gamePadState = new Dictionary<PlayerIndex,GamePadState>();
        private static Dictionary<PlayerIndex, GamePadState> oldGamePadState = new Dictionary<PlayerIndex, GamePadState>();
        public void AddOld(PlayerIndex index, GamePadState state)
        {
            oldGamePadState[index] = state;  // Set breakpoint here
            // When the breakpoint trips, look at the stack trace to find out
            // who is calling this method
        }
        public void AddNew(PlayerIndex index, GamePadState state)
        {
            gamePadState[index] = state;
        }
    }
    
