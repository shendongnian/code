    // N = Initial Team Count
    // R = Zero-Based Round #
    // 2 ^ ((N ^ 0.5) - (R + 1))
    public double GamesPerRound(int totalTeams, int currentRound) {
        var result = Math.Pow(2, Math.Sqrt(totalTeams) - (currentRound + 1));
    
        // Happens if you exceed the maximum possible rounds given number of teams
        if (result < 1.0F) throw new InvalidOperationException();
        return result;
    }
