    public static void HighScore()
    {
        int gameList = 1;
        List<int> Points = new List<int>() { 10,20,39,40,50};
        foreach (var item in Points)
        {
           Console.WriteLine($"Game {gameList} Score : {item}");
            gameList++;
        }
    }
