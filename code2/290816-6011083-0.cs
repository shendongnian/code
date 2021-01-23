    // All ball rolls, including misses as zeros!
    private readonly IList<int> balls = new List<int>();
    public int CalculateScore()
    {
        var score = 0;
        for (var i = 0; i < balls.Count; i++)
        {
            if (balls[i] == 10)
                score += balls[i] + balls[i + 1] + balls[i + 2];
            else
                score += balls[i];
        }
        return score;
    }
