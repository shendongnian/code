    // Checks whether the King is moving from or into check.
    // Checks whether the King is moving across attacked squares.
    internal bool IsCastlingMoveLegal(Board board, Move move)
    {
        if (move.IsCastlingOO)
        {
            if (move.IsWhiteMove)
            {
                // Are any of the White kingside castling squares (E1/F1/G1) attacked?
                return !this.IsAttacked(board, Constants.MASK_EG[Constants.WHITE_MOVE], false);
            }
            else
            {
                // Are any of the Black kingside castling squares (E8/F8/G8) attacked?
                return !this.IsAttacked(board, Constants.MASK_EG[Constants.BLACK_MOVE], true);
            }
        }
        else if (move.IsCastlingOOO)
        {
            if (move.IsWhiteMove)
            {
                // Are any of the White queenside castling squares (E1/D1/C1) attacked?
                return !this.IsAttacked(board, Constants.MASK_CE[Constants.WHITE_MOVE], false);
            }
            else
            {
                // Are any of the Black queenside castling squares (E8/D8/C8) attacked?
                return !this.IsAttacked(board, Constants.MASK_CE[Constants.BLACK_MOVE], true);
            }
        }
        // Not a castling move!
        else
        {
            Debug.Assert(false, "Not a castling move!");
            return true;
        }
    }
