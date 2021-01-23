    void makePDF()
     {
     Response.ContentType = "application/pdf";
    
     Response.AddHeader("content-disposition", "attachment;filename=test.pdf");
    
     Response.Cache.SetCacheability(HttpCacheability.NoCache);
    
     string imageFilePath = Server.MapPath(".") + "/images/test.jpg";
    
     iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
    
     // Page site and margin left, right, top, bottom is defined
     Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    
     //Resize image depend upon your need
     //For give the size to image
     jpg.ScaleToFit(3000, 770);
    
     //If you want to choose image as background then,
    
     jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
    
     //If you want to give absolute/specified fix position to image.
     jpg.SetAbsolutePosition(7, 69);
    
     PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    
     pdfDoc.Open();
    
     pdfDoc.NewPage();
    
     Paragraph paragraph = new Paragraph("this is the testing text for demonstrate the image is in background \n\n\n this is the testing text for demonstrate the image is in background");
    
     pdfDoc.Add(jpg);
    
     pdfDoc.Add(paragraph);
    
     pdfDoc.Close();
    
     Response.Write(pdfDoc);
    
     Response.End();
     }
