    using DocumentFormat.OpenXml.Packaging;
    using x = DocumentFormat.OpenXml.Spreadsheet;
    
    class Program
    {
    private static readonly string placeHolder = "$$value";
    
    static void Main()
    {
        var templatePath = @"C:\Temp\template.xlsx";
        var resultPath = @"C:\Temp\result.xlsx";
        string replacementText = "test";
    
        using (Stream xlsxStream = new MemoryStream())
        {
            // Read template from disk
            using (var fileStream = File.OpenRead(templatePath)) 
                fileStream.CopyTo(xlsxStream);
                    
            // Do replacements
            ProcessTemplate(xlsxStream, replacementText);
    
            // Reset stream to beginning
            xlsxStream.Seek(0L, SeekOrigin.Begin);
                    
            // Write results back to disk
            using (var resultFile = File.Create(resultPath))
                xlsxStream.CopyTo(resultFile);
        }
    }
    
    private static void ProcessTemplate(Stream template, string replacementText)
    {
        using (var workbook = SpreadsheetDocument.Open(template, true, new OpenSettings { AutoSave = true }))
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
