    var a = Guid.NewGuid();
    
    using (var pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f))
    using (var writer2 = PdfWriter.GetInstance(pdfDoc, new FileStream(a.ToString()+".pdf", FileMode.Create));
    {
        writer2.SetFullCompression();
        writer2.CloseStream = true;
    
        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(AppContext.BaseDirectory + "Ehrungsantrag.png");
        img.SetAbsolutePosition(0, 0);
        img.ScaleAbsoluteHeight(pdfDoc.PageSize.Height);
        img.ScaleAbsoluteWidth(pdfDoc.PageSize.Width);
        pdfDoc.Open();
        pdfDoc.NewPage();
        pdfDoc.Add(img);
    
        pdfDoc.Close();
        writer2.Close()
    }
