    public static void CreateNewWordDocument(string document)
    {
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(document, WordprocessingDocumentType.Document))
        {
            // Set the content of the document so that Word can open it.
            MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
            SetMainDocumentContent(mainPart);
        }
    }
