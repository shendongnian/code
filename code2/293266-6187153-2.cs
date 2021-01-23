    //G = current game.
    //T = total teams
    //Next round game = (T / 2) + RoundedUp(G / 2)
    //i. e.: G = 2, T = 8
           //Next round game = (8 / 2) + RoundedUp(2 / 2) = 5
    public int NextGame(int totalTeams, int currentGame) {
        return (totalTeams / 2) + (int)Math.Ceiling((double)currentGame / 2);
    }
