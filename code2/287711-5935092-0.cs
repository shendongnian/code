    private static readonly string placeHolder = "$$value";
    
    static void Main()
    {
        var path = @"\\share\folder\filename.xlsx";
        string replacementText = "test";
    
        using (var workbook = SpreadsheetDocument.Open(path, true, new OpenSettings { AutoSave = true }))
        {
            // Replace shared strings
            SharedStringTablePart sharedStringsPart = workbook.WorkbookPart.SharedStringTablePart;
            IEnumerable<x.Text> sharedStringTextElements = sharedStringsPart.SharedStringTable.Descendants<x.Text>();
            DoReplace(sharedStringTextElements, replacementText);
    
            // Replace inline strings
            IEnumerable<WorksheetPart> worksheetParts = workbook.GetPartsOfType<WorksheetPart>();
            foreach (var worksheet in worksheetParts)
            {
                var allTextElements = worksheet.Worksheet.Descendants<x.Text>();
                DoReplace(allTextElements, replacementText);
            }
    
        } // AutoSave enabled
    }
    
    private static void DoReplace(IEnumerable<x.Text> textElements, string replacementText)
    {
        foreach (var text in textElements)
        {
            if (text.Text.Contains(placeHolder))
                text.Text = text.Text.Replace(placeHolder, replacementText);
        }
    }
