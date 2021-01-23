    public static decimal Sqrt(decimal x, decimal? guess = null)
    {
        var ourGuess = guess.GetValueOrDefault(x / 2m);
        var result = x / ourGuess;
        var average = (ourGuess + result) / 2m;
        if (average == ourGuess)
            return average;
        else
            return Sqrt(x, average);
    }
