    //...
    // Position is a class
    private bool checkMate(ref int numberOfPlies, ref ChessPosition position, int maxNumberOfPlies, List<Move> moves)
    {
        if (numberOfPlies > maxNumberOfPlies)
            return false;
        position.makeMove(moves[numberOfPlies]);
        if (!(position.getSuccessOfLastMove())))
            return false;
        numberOfPlies++;
        return ((
                ((isCheckMate()) ||
                ((checkMate(ref numberOfPlies, ref position, maxNumberOfPlies, moves)))
               ));
    }
    //...
