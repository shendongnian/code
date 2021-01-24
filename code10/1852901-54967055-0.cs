    static Cell AddCellWithText(string text) 
    { 
        Cell c1 = new Cell();
        c1.CellReference = "B2"; //The required position of cell in excel grid
        c1.DataType = CellValues.InlineString;
    
        InlineString inlineString = new InlineString(); 
        Text t = new Text(); 
        t.Text = text; 
        inlineString.AppendChild(t);
    
        c1.AppendChild(inlineString);
    
        return c1; 
    }
