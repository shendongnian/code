    foreach (Excel.PivotLine pl in pvtTable.PivotRowAxis.PivotLines)
    {
        if (pl.LineType == Excel.XlPivotLineType.xlPivotLineSubtotal)
        {
            foreach (Excel.Range cell in pvtTable.DataBodyRange.Rows(pl.Position).Cells){
                System.Diagnostics.Debug.WriteLine(cell);
            }
        }
    }
