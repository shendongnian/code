      public void FallDown()
       {
            for (var row = 0; row < RowCount - 1; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    if (tiles[row + 1, column] == 0 && tiles[row, column] != 0)
                    {
                        tiles[row + 1, column] = tiles[row, column];
                        tiles[row, column] = 0;
                        row = 0;
                        column = 0;
                    }
                }
            }
        }
