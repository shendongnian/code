    //load an existing pdf document
    PdfDocument doc = new PdfDocument();
    doc.LoadFromFile(@"C:\Users\Administrator\Desktop\sample.pdf");
    //loop through the pages
    for (int i = 0; i < doc.Pages.Count; i++)
    {
        //get the specfic page
        PdfPageBase page = doc.Pages[i];
        //define HTML string
        string htmlText = "<b>XXX lnc.</b><br/><i>Tel:889 974 544</i><br/><font color='#FF4500'>Website:www.xxx.com</font>";
        //render HTML text
        PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12);
        PdfBrush brush = PdfBrushes.Black;
        PdfHTMLTextElement richTextElement = new PdfHTMLTextElement(htmlText, font, brush);
        richTextElement.TextAlign = TextAlign.Left;
        //draw html string at the top white space
        richTextElement.Draw(page.Canvas, new RectangleF(70, 20, page.GetClientSize().Width - 140, page.GetClientSize().Height - 20));
    }
    //save to file
    doc.SaveToFile("output.pdf");
