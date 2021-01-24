    class User
    {
        public int HighScore { get; private set; } = 0;
        public double AverageScore => 
            this.GamesPlayed > 0 ? this.TotalScore / (double)this.GamesPlayed : 0;
        private int GamesPlayed { get; set; } = 0;
        private int TotalScore { get; set; } = 0;
        public void GameOver(int score)
        {
            this.HighScore = Math.Max(this.HighScore, score);
            this.GamesPlayed += 1;
            this.TotalScore += score;
        }
    }
