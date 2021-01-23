    private TableCell newCell(String cellText)
    {
        return newCell(cellText, HorizontalAlign.Right, "normalFont");
    }
    
    private TableCell newCell(String cellText, String cssClass)
    {
        return newCell(cellText, HorizontalAlign.Right, cssClass);
    }
    
    private TableCell newCell(String cellText, HorizontalAlign alignment, String cssClass)
    {
        return newCell(cellText, alignment, cssClass, 1);
    }
    
    private TableCell newCell(String cellText, HorizontalAlign alignment, String cssClass, Int32 colSpan)
    {
        TableCell tc = new TableCell();
        tc.Text = cellText;
        tc.HorizontalAlign = alignment;
        tc.VerticalAlign = VerticalAlign.Top;
        tc.CssClass = cssClass;
        tc.ColumnSpan = colSpan;
        return tc;
    }
