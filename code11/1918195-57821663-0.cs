    private void FixDocument(string outputFile)
    {
        using (var wdDoc = WordprocessingDocument.Open(outputFile, true))
        {
            var mainPart = wdDoc.MainDocumentPart;
            var sections = mainPart.Document.Descendants<SectionProperties>().Skip(1);
            
            foreach (var section in sections)
            {
                section.RemoveAllChildren<HeaderReference>();
            }
        }
    }
