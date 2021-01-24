    public XDocument ExtractStylesPart(string sourceFile)
    {
        XDocument styles = null;
        // open readonly
        using (var document = WordprocessingDocument.Open(sourceFile, false))
        {
            var docPart = document.MainDocumentPart;
            StylesPart stylesPart = docPart.StyleDefinitionsPart;
            if (stylesPart != null)
            {
                using (var reader = XmlNodeReader.Create(
                           stylesPart.GetStream(FileMode.Open, FileAccess.Read)))
                {
                    // Create the XDocument.
                    styles = XDocument.Load(reader);
                }
            }
        }
        // Return the XDocument instance.
        return styles;
    } 
