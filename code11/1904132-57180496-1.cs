    string sourceFile = @"C:\Users\Owl\Desktop\Template.docm";
    string targetFile = @"C:\Users\Owl\Desktop\Result.docx";
    File.Copy(sourceFile, targetFile, true);
    using (WordprocessingDocument document = WordprocessingDocument.Open(targetFile, true))
    {
        document.ChangeDocumentType(WordprocessingDocumentType.Document);
        foreach (FieldCode field in document.MainDocumentPart.RootElement.Descendants<FieldCode>())
        {
            ReplaceMergeFieldWithText(field, "some text");
        }
        document.MainDocumentPart.Document.Save();
    }
    private void ReplaceMergeFieldWithText(FieldCode field, string replacementText)
    {
        if (field == null || replacementText == string.Empty)
        {
            return;
        }
        Run rFldParent = (Run)field.Parent;
        List<Run> runs = new List<Run>();
        runs.Add(rFldParent.PreviousSibling<Run>()); // begin
        runs.Add(rFldParent.NextSibling<Run>()); // separate
        runs.Add(runs.Last().NextSibling<Run>()); // text
        runs.Add(runs.Last().NextSibling<Run>()); // end
        foreach(Run run in runs)
        {
            run.Remove();
        }
        field.Remove(); // instrText
        rFldParent.Append(new Text(replacementText));
    }
