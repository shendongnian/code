    Page page = (Page)doc.Pages[1];
    var text = new TextFragment("LINK");
    text.Position = new Position(300, 300);
    Aspose.Pdf.WebHyperlink link = new WebHyperlink("www.google.com");
    text.Hyperlink = link;
    text.Margin.Left = -48;
    text.Margin.Top = 687;
    text.Margin.Bottom = -150;
    text.TextState.Underline = true;
    text.TextState.FontSize = 11;
            
    text.TextState.ForegroundColor = Aspose.Pdf.Color.DeepSkyBlue;
    text.TextState.BackgroundColor = Aspose.Pdf.Color.White;
    page.Paragraphs.Add(text);
