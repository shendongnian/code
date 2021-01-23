    Image RenderPage(PDFLibNet.PDFWrapper doc, int page)
    {
        doc.CurrentPage = page + 1;
        doc.CurrentX = 0;
        doc.CurrentY = 0;
        using (var box = new PictureBox())
        {
            // have to give the document a handle to render into
            doc.RenderPage(box.Handle);
            // create an image to draw the page into
            var buffer = new Bitmap(doc.PageWidth, doc.PageHeight);
            doc.ClientBounds = new Rectangle(0, 0, doc.PageWidth, doc.PageHeight);
            using (var g = Graphics.FromImage(buffer))
            {
                var hdc = g.GetHdc();
                try
                {
                    doc.DrawPageHDC(hdc);
                }
                finally
                {
                    g.ReleaseHdc();
                }
            }
            return buffer;
        }
    }
