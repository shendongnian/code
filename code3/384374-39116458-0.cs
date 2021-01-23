    string sourceFile = @"C:\Template.docx";
    string targetFile = @"C:\Result.docx";
    File.Copy(sourceFile, targetFile, true);
    using (WordprocessingDocument document = WordprocessingDocument.Open(targetFile, true))
    {
        // If your sourceFile is a different type (e.g., .DOTX), you will need to change the target type like so:
        document.ChangeDocumentType(WordprocessingDocumentType.Document);
        // Get the MainPart of the document
        MainDocumentPart mainPart = document.MainDocumentPart;
        var mergeFields = mainPart.RootElement.Descendants<FieldCode>();
        var mergeFieldName = "SenderFullName";
        var replacementText = "John Smith";
        ReplaceMergeFieldWithText(mergeFields, mergeFieldName, replacementText);                   
        // Save the document
        mainPart.Document.Save();
    }
    private void ReplaceMergeFieldWithText(IEnumerable<FieldCode> fields, string mergeFieldName, string replacementText)
    {
        var field = fields
            .Where(f => f.InnerText.Contains(mergeFieldName))
            .FirstOrDefault();
        if (field != null)
        {
            // Get the Run that contains our FieldCode
            // Then get the parent container of this Run
            Run rFldCode = (Run)field.Parent; 
            var container = rFldCode.Parent; 
            // Get the three (3) other Runs that make up our merge field
            Run rBegin = rFldCode.PreviousSibling<Run>();
            Run rSep = rFldCode.NextSibling<Run>();
            Run rEnd = rText.NextSibling<Run>();
            // Get the Run that holds the Text element for our merge field
            // Get the Text element and replace the text content 
            Run rText = rSep.NextSibling<Run>();
            Text t = rText.GetFirstChild<Text>();
            t.Text = replacementText;
            // Remove all the four (4) Runs for our merge field
            rFldCode.Remove();
            rBegin.Remove();
            rSep.Remove();
            rEnd.Remove();
        }
    }
