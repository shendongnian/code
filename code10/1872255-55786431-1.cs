    class User
    {
        public int HighScore { get; private set; } = 0;
        public double AverageScore { get; private set; } = 0;
        private int GamesPlayed { get; set; } = 0;
        public void GameOver(int score)
        {
            this.HighScore = Math.Max(this.HighScore, score);
            // get the prev total score then increase with the current score and get the new average in the end (also increase the GamesPlayed)
            this.AverageScore = ((this.AverageScore * this.GamesPlayed) + score) / ++this.GamesPlayed;
        }
    }
