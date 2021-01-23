    private bool IsCellToHighlight(GridViewCell cell)
    {
    bool highlightCell = false;
    // Put your cell checking condition
    // Example ..
    highlightCell = (string.Compare(cell.Text, "Check Value", true) == 0);
    return highlightCell;
    }
    private void HighlightCells(GridViewRow row)
    {
    for(int c=0; r<row.Cells.Count; c++)
    {
    if(this.IsCellToHighlight(row.Cells[c]))
    {
    // Apply required styling Code
    // ..
    }
    }
    }
