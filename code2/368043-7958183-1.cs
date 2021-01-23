    private static void BuildDocument(string fileName, List<string> text)
    {
        using (var wordDoc = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
        {
            var mainPart = wordDoc.AddMainDocumentPart();
            mainPart.Document = new Document();
            var run = new Run();
            foreach (string currText in text)
            {
                run.AppendChild(new Text(currText));
                run.AppendChild(new CarriageReturn());
            }
            var paragraph = new Paragraph(run);
            var body = new Body(paragraph);
            mainPart.Document.Append(body);
            var runProp = new RunProperties();
            var runFont = new RunFonts { Ascii = "Arial" };
            // 48 half-point font size
            var size = new FontSize { Val = new StringValue("48") }; 
            runProp.Append(runFont);
            runProp.Append(size);
            run.PrependChild(runProp);
            mainPart.Document.Save();
            wordDoc.Close();
        }
    }
