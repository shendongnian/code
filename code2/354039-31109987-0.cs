    var doc = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf("Your html in a string",PageSize.A4);
      PdfPage page = new PdfPage();
      XImage img = XImage.FromGdiPlusImage(bitmap);
      doc.Pages.Add(page);
      XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
      xgr.DrawImage(img, 0, 0);
      doc.Save(Server.MapPath("test.pdf"));
      doc.Close();
