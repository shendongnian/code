    // creation of the document with a certain size and certain margins
    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
    
    // creation of the different writers
    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new System.IO.FileStream(Server.MapPath("~/App_Data/result.pdf"), System.IO.FileMode.Create));
    
    // load the tiff image and count the total pages
    System.Drawing.Bitmap bm = new System.Drawing.Bitmap(Server.MapPath("~/App_Data/source.tif"));
    int total = bm.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
    
    document.Open();
    iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
    for (int k = 0; k < total; ++k)
    {
    	bm.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, k);
    	iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bm, System.Drawing.Imaging.ImageFormat.Bmp);
    	// scale the image to fit in the page
    	img.ScalePercent(72f / img.DpiX * 100);
    	img.SetAbsolutePosition(0, 0);
    	cb.AddImage(img);
    	document.NewPage();
    }
    document.Close();
