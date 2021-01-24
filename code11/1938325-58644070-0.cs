    Document pdfDoc = null;
    PdfWriter writer2 = null;
    try
    {
       var a = Guid.NewGuid();
       pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
       writer2 = PdfWriter.GetInstance(pdfDoc, new FileStream(a.ToString()+".pdf", FileMode.Create));
       writer2.SetFullCompression();
       writer2.CloseStream = true;
    
       iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(AppContext.BaseDirectory + "Ehrungsantrag.png");
       img.SetAbsolutePosition(0, 0);
       img.ScaleAbsoluteHeight(pdfDoc.PageSize.Height);
       img.ScaleAbsoluteWidth(pdfDoc.PageSize.Width);
       pdfDoc.Open();
       pdfDoc.NewPage();
       pdfDoc.Add(img);
    }
    catch (iTextSharp.text.DocumentException dex) 
    {
       // special error handling
    }
    catch (Exception ex) 
    {
       // generic error handling
    }
    finally
    {
            pdfDoc.Close();
            pdfDoc = null;
 
            writer2.Close();
    }
