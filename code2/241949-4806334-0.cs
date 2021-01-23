    public void SearchAndReplace(Dictionary<string, string> tokens)
    {
        using (WordprocessingDocument doc = WordprocessingDocument.Open(_filename, true))
            ProcessDocument(doc, tokens);
    }
    private string GetPartAsString(OpenXmlPart part)
    {
        string text = String.Empty;
        using (StreamReader sr = new StreamReader(part.GetStream()))
        {
            text = sr.ReadToEnd();
        }
        return text;
    }
    private void SavePart(OpenXmlPart part, string text)
    {
        using (StreamWriter sw = new StreamWriter(part.GetStream(FileMode.Create)))
        {
            sw.Write(text);
        }
    }
    private void ProcessDocument(WordprocessingDocument doc, Dictionary<string, string> tokenDict)
    {
        ProcessPart(doc.MainDocumentPart, tokenDict);
        foreach (var part in doc.MainDocumentPart.HeaderParts)
        {
            ProcessPart(part, tokenDict);
        }
        foreach (var part in doc.MainDocumentPart.FooterParts)
        {
            ProcessPart(part, tokenDict);
        }
    }
    private void ProcessPart(OpenXmlPart part, Dictionary<string, string> tokenDict)
    {
        string docText = GetPartAsString(part);
        foreach (var keyval in tokenDict)
        {
            Regex expr = new Regex(_starttag + keyval.Key + _endtag);
            docText = expr.Replace(docText, keyval.Value);
        }
        SavePart(part, docText);
    }
