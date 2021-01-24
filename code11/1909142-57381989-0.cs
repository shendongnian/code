    class Game {    
        List<Player> playerList;
        ArrayList lifeValues;
        System.Timers.Timer lifeCheckTimer;
        Game() {
            playerList = new List<Player>();
            //add all players that have been instantiated to the above list here
            lifeValues = new ArrayList();
            //add all the player.Life values to the above list here
            //these will need to be added in the same order
            lifeCheckTimer = new System.Timers.Timer();
            lifeCheckTimer.Elapsed += new ElapsedEventHandler(lifeCheckElapsed);
            //you can change the 500 (0.5 seconds) below to whatever interval you want to 
            //check for a change in players life values (in milliseconds)
            lifeCheckTimer.Interval = 500;
            lifeCheckTimer.Enabled = true;
        }
        private static void lifeCheckElapsed(object source, ElapsedEventArgs e)
        {
            for (int i = 0; i < playerList.Count(); i ++) {
                if (((Player)playerList[i]).Life != lifeValues[i])
                    OnPlayerLifeChange();
                lifeValues[i] = ((Player)playerList[i]).Life;
            }
        }
    }
