    Document pdfDoc = null;
    PdfWriter writer2 = null;
    System.IO.FileStream fs = null; // <- create the FileStream
    try
    {
       var a = Guid.NewGuid();
       pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
       fs =  new FileStream(a.ToString()+".pdf", FileMode.Create);
       writer2 = PdfWriter.GetInstance(pdfDoc, fs);
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
            
           // That was the eroor -> always close open filehandles explicity !
           fs.Close(); 
    }
