    table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
    table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
    table.Rows.AllowBreakAcrossPages = (int)Microsoft.Office.Core.MsoTriState.msoFalse;
    Word.ParagraphFormat pf = table.Range.ParagraphFormat;
    pf.KeepWithNext = (int)Microsoft.Office.Core.MsoTriState.msoTrue;
    pf.KeepTogether = (int)Microsoft.Office.Core.MsoTriState.msoTrue;
