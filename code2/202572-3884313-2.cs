    public void insertNewValue(int row, int col, uint value)
    {
        if(!isMoveLegal(row, col, value))
            throw ...
        
        theBoard[row, col] = value;
        uint mask = 1u << (int)(value - 1u);
        maskForNumbersSetInRow[row] |= mask;
        maskForNumbersSetInCol[col] |= mask;
        int boxRowNumber = row / 3;
        int boxColNumber = col / 3;
        maskForNumbersSetInBox[boxRowNumber, boxColNumber] |= mask;
        
    }
