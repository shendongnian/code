    Globals.ThisAddIn.Application.ActiveDocument.Range(
    Globals.ThisAddIn.Application.ActiveDocument.Content.End-1,
    Globals.ThisAddIn.Application.ActiveDocument.Content.End-1).Select();
    object missing = System.Type.Missing;
    Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
    Word.Table newTable = Globals.ThisAddIn.Application.ActiveDocument.Tables.Add(
    currentRange, 3, 4, ref missing, ref missing);
    
    // Get all of the borders except for the diagonal borders.
    Word.Border[] borders = new Word.Border[6];
    borders[0] = newTable.Borders[Word.WdBorderType.wdBorderLeft];
    borders[1] = newTable.Borders[Word.WdBorderType.wdBorderRight];
    borders[2] = newTable.Borders[Word.WdBorderType.wdBorderTop];
    borders[3] = newTable.Borders[Word.WdBorderType.wdBorderBottom];
    borders[4] = newTable.Borders[Word.WdBorderType.wdBorderHorizontal];
    borders[5] = newTable.Borders[Word.WdBorderType.wdBorderVertical];
    
    // Format each of the borders. 
    foreach (Word.Border border in borders)
    {
        border.LineStyle = Word.WdLineStyle.wdLineStyleSingle;
        border.Color = Word.WdColor.wdColorBlue;
    }
