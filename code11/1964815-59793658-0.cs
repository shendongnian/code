    int row, col;
    bool isZeroAbove = true;
    bool isZeroBelow = true;
    for (row = 0; row < 6; row++)
        for (col = 0; col < 6; col++)
            if (matrix[row, col] != 0)
                if (row > col)
                {
                    isZeroBelow = false;
                    break;
                }
                else if (row < col)
                {
                    isZeroAbove = false;
                    break;
                }
