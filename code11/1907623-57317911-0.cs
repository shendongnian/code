    public bool IsKingThreatened()
    {
        GameObject[] kings = GameObject.FindGameObjectsWithTag("King");
        return kings
            .Where(king => currentPlayer.pieces.Contains(king))
            .Select(GridForPiece)
            .Any(kingPosition => threatenedSquares.Contains(kingPosition));
    }
