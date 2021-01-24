    File file = new File(myPDF);
    
    //pattern
    var pattern = new Regex("kullan", RegexOptions.IgnoreCase);
    var textExtractor = new TextExtractor();
    
    foreach (var page in file.Document.Pages)
    {
        var strings = textExtractor.Extract(page);
        var matchingText = pattern.Matches(TextExtractor.ToString(strings));
    }
