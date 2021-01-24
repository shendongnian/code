    public void HighScore()
        {
            int gameList = 1;
            foreach (var item in Points)
            {
                Console.WriteLine($"{name} : Game {gameList} Score : {item} : Level [{GameLevel}]");
                gameList++;
            }
        }
