    Bitmap bitmap = new Bitmap(790, 1800);
    Graphics g = Graphics.FromImage(bitmap);
    XGraphics xg = XGraphics.FromGraphics(g, new XSize(bitmap.Width, bitmap.Height));
    TheArtOfDev.HtmlRenderer.PdfSharp.HtmlContainer c = new TheArtOfDev.HtmlRenderer.PdfSharp.HtmlContainer();
    c.SetHtml("Your html in a string here");
    
    PdfDocument pdf = new PdfDocument();
    PdfPage page = new PdfPage();
    XImage img = XImage.FromGdiPlusImage(bitmap);
    pdf.Pages.Add(page);
    XGraphics xgr = XGraphics.FromPdfPage(pdf.Pages[0]);
    c.PerformLayout(xgr);
    c.PerformPaint(xgr);
    xgr.DrawImage(img, 0, 0);
    pdf.Save("test.pdf");
