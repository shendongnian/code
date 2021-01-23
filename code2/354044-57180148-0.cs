    using PdfSharp.Pdf;
    using PdfSharp;
    using PdfSharp.Drawing;
    using TheArtOfDev.HtmlRenderer.PdfSharp;
    //create a pdf document
    using (PdfDocument doc = new PdfDocument())
    {
        doc.Info.Title = "StackOverflow Demo PDF";
    
        //add a page
        PdfPage page = doc.AddPage();
        page.Size = PageSize.A4;
    
        //fonts and styles
        XFont font = new XFont("Arial", 10, XFontStyle.Regular);
        XSolidBrush brush = new XSolidBrush(XColor.FromArgb(0, 0, 0));
    
        using (XGraphics gfx = XGraphics.FromPdfPage(page))
        {
            //write a normal string
            gfx.DrawString("A normal string written to the PDF.", font, brush, new XRect(15, 15, page.Width, page.Height), XStringFormats.TopLeft);
    
            //write the html string to the pdf
            using (var container = new HtmlContainer())
            {
                var pageSize = new XSize(page.Width, page.Height);
    
                container.Location = new XPoint(15,  45);
                container.MaxSize = pageSize;
                container.PageSize = pageSize;
                container.SetHtml("This is a <b>HTML</b> string <u>written</u> to the <font color=\"red\">PDF</font>.<br><br><a href=\"http://www.google.nl\">www.google.nl</a>");
    
                using (var measure = XGraphics.CreateMeasureContext(pageSize, XGraphicsUnit.Point, XPageDirection.Downwards))
                {
                    container.PerformLayout(measure);
                }
    
                gfx.IntersectClip(new XRect(0, 0, page.Width, page.Height));
    
                container.PerformPaint(gfx);
            }
        }
    
        //write the pdf to a byte array to serve as download, attach to an email etc.
        byte[] bin;
        using (MemoryStream stream = new MemoryStream())
        {
            doc.Save(stream, false);
            bin = stream.ToArray();
        }
    }
