    private void AddBalancingLine(String balDescription, Decimal balAmount)
    {
        TableRow tr = new TableRow();
        tr.Height = Unit.Pixel(17);
        tblDetailLines.Rows.Add(tr);
    
        tr.Cells.Add(newCell(""));
        tr.Cells.Add(newCell(""));
        tr.Cells.Add(newCell(""));
        tr.Cells.Add(newCell(balDescription, HorizontalAlign.Left, "normalFont", 8));
        tr.Cells.Add(newCell(nullAmount(balAmount), HorizontalAlign.Right, "normalFont", 2));
    }
