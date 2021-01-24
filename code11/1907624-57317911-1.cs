    public bool IsKingThreatened()
    {
        GameObject currentKing = GameObject.FindGameObjectsWithTag("King")
            .Single(king => currentPlayer.pieces.Contains(king));
        Vector2Int kingPosition = GridForPiece(kingPosition);
        return threatenedSquares.Contains(kingPosition);
    }
