    private int[] GetLastRowCol(Ex.Worksheet ws)
        {
            Ex.Range last = ws.Cells.SpecialCells(Ex.XlCellType.xlCellTypeLastCell, Type.Missing);
            bool isMerged = (bool)last.MergeCells;
            if (isMerged)
            {
                last.UnMerge();
                last = ws.Cells.SpecialCells(Ex.XlCellType.xlCellTypeLastCell, Type.Missing);
            }
            return new int[2] { last.Row, last.Column };
        }
