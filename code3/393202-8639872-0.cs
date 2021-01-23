    public bool IsChipLeader(Form1 game)
    {
        // Maybe include check that "this" is part of the game...
        return this.Stack == game.Players.Max(s => s.Stack);
    }
