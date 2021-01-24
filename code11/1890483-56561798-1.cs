    using (var stream = new FileStream(@"C:\File\0.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
    {
        Document document = new Document(PageSize.A4, 0, 0, 0, 0);
        var writer = PdfWriter.GetInstance(document, stream);    
        var bitmap = new System.Drawing.Bitmap(@"C:\File\0.tiff"); 
        var pages = bitmap.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
    
        document.Open();
        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
        for (int i = 0; i < pages; ++i)
        {
            bitmap.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, i);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Bmp);
            // scale the image to fit in the page 
            //img.ScalePercent(72f / img.DpiX * 100);
            //img.SetAbsolutePosition(0, 0);
            cb.AddImage(img);
            document.NewPage();
        }
       }
       document.Close();
    }
