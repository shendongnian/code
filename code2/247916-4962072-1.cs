    public static void findingTableBounds()
        {
            for (int column = 1; column < currentRow; column++)
            {
                double? dateCol;
                dateCol = ((Excel.Range)workSheet.Cells[currentRow, 1]).Value2;
                if (dateCol == null)
                {
                    Console.WriteLine("Total Row: {0}", totalRow);
                    currentRow = 2;           
                }
                else
                {
                    currentRow++;
                    totalRow++;
                }
            }
            
            for (int row = 1; row < currentCol; row++)
            {
                double? headerRow;
                headerRow = ((Excel.Range)workSheet.Cells[1, currentCol]).Value2;
                if (headerRow == null)
                {
                    Console.WriteLine("Total Column: {0}", totalCol);
                    currentCol = 2;
                }
                else
                {
                    currentCol++;
                    totalCol++;
                }
            }
        }
