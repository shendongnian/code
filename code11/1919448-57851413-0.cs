    public static class playerscore            
    {
        public static int Score
        {
            get { return PlayerPrefs.GetInt("score", 0);} 
            set { PlayerPrefs.SetInt("score", value); }
        }
    }
