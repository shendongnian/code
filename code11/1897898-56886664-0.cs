    XLWorkbook wb = new XLWorkbook(@"c:\temp.xlsx");
    IXLWorksheet worksheet = wb.Worksheet(1);
    foreach (IXLRow row in worksheet.RowsUsed())
    {
        row.Cell("J").RichText.ClearText();
        foreach (var rt in row.Cell("E").RichText)
        {
            row.Cell("J").RichText.AddText(rt.Text).CopyFont(rt);
        }
        row.Cell("J").RichText.AddText(" ");
        foreach (var rt in row.Cell("F").RichText)
        {
            row.Cell("J").RichText.AddText(rt.Text).CopyFont(rt);
        }
        row.Cell("J").RichText.AddText(" ");
        foreach (var rt in row.Cell("G").RichText)
        {
            row.Cell("J").RichText.AddText(rt.Text).CopyFont(rt);
        }
    }
    wb.Save();
