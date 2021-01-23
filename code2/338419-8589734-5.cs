    // If White can still castle kingside...
    if ((board.WhiteCastlingStatus & Board.EnumCastlingStatus.CanCastleOO) != 0)
    {
        // And the White kingside castling squares (F1/G1) aren't occupied...
        if ((Constants.MASK_FG[Constants.WHITE_MOVE] & board.OccupiedSquares) == 0)
        {
            board.MoveBuffer[moveIndex++] = Constants.WHITE_CASTLING_OO;
        }
    }
    // If White can still castle queenside...
    if ((board.WhiteCastlingStatus & Board.EnumCastlingStatus.CanCastleOOO) != 0)
    {
        // And the White queenside castling squares (D1/C1/B1) aren't occupied...
        if ((Constants.MASK_BD[Constants.WHITE_MOVE] & board.OccupiedSquares) == 0)
        {
            board.MoveBuffer[moveIndex++] = Constants.WHITE_CASTLING_OOO;
        }
    }
