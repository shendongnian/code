    private static Move GetBestMove(Color color, Board board, int depth)
    {
        var bestMoves = new List<Move>();
        IEnumerable<Move> validMoves = board.GetValidMoves(color);
        int highestScore = int.MinValue;
        Board boardAfterMove;
        int tmpScore;
        var rand = new Random();
        Debug.WriteLine("{0}'s Moves:", color);
        foreach (Move move in validMoves)
        {
            boardAfterMove = board.Clone().ApplyMove(move);
            if (move.IsJump && !move.IsCrowned && boardAfterMove.GetJumps(color).Any())
                tmpScore = NegaMax(color, boardAfterMove, depth);
            else
                tmpScore = -NegaMax(Board.Opposite(color), boardAfterMove, depth);
            Debug.WriteLine("{0}: {1}", move, tmpScore);
            if (tmpScore > highestScore)
            {
                bestMoves.Clear();
                bestMoves.Add(move);
                highestScore = tmpScore;
            }
            else if (tmpScore == highestScore)
            {
                bestMoves.Add(move);
            }
        }
        return bestMoves[rand.Next(bestMoves.Count)];
    }
    private static int NegaMax(Color color, Board board, int depth)
    {
        IEnumerable<Move> validMoves = board.GetValidMoves(color);
        int highestScore = int.MinValue;
        Board boardAfterMove;
        if (depth <= 0 || !validMoves.Any())
            return BoardScore(color, board);
        foreach (Move move in validMoves)
        {
            boardAfterMove = board.Clone().ApplyMove(move);
            if (move.IsJump && !move.IsCrowned && boardAfterMove.GetJumps(color).Any())
                highestScore = Math.Max(highestScore, NegaMax(color, boardAfterMove, depth));
            else
                highestScore = Math.Max(highestScore, -NegaMax(Board.Opposite(color), boardAfterMove, depth - 1));
        }
        return highestScore;
    }
    private static int BoardScore(Color color, Board board)
    {
        if (!board.GetValidMoves(color).Any()) return -1000;
        return board.OfType<Checker>().Sum(c => (c.Color == color ? 1 : -1) * (c.Class == Class.Man ? 2 : 3));
    }
