    // N = Initial Team Count
    // R = Zero-Based Round #
    // Games = (N / (2 ^ R)) / 2
    public double GamesPerRound(int totalTeams, int currentRound) {
        var result = (totalTeams / Math.Pow(2, currentRound)) / 2;
    
        // Happens if you exceed the maximum possible rounds given number of teams
        if (result < 1.0F) throw new InvalidOperationException();
        return result;
    }
