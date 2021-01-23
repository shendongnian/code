    public static void WriteHyperlink(this ExcelRange cell, string text, string url, bool excelHyperlink = false, bool underline = true)
    {
        if (string.IsNullOrWhiteSpace(text))
            return;
    
        // trying to reuse hyperlink style if defined
        var workBook = cell.Worksheet.Workbook;
        string actualStyleName = underline ? HyperLinkStyleName : HyperLinkNoUnderlineStyleName;
    
        var hyperlinkStyle = workBook.Styles.NamedStyles.FirstOrDefault(s => s.Name == actualStyleName);
        if (hyperlinkStyle == null)
        {
            var namedStyle = workBook.Styles.CreateNamedStyle(actualStyleName);  
            namedStyle.Style.Font.UnderLine = underline;
            namedStyle.Style.Font.Color.SetColor(Color.Blue);
        }
    
        if (excelHyperlink)
            cell.Hyperlink = new ExcelHyperLink(url) { Display = text };
        else
        {
            cell.Hyperlink = new Uri(url);
            cell.Value = text;
            cell.StyleName = actualStyleName;
        }
    }
