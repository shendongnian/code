     string Folderpath ="your path";
     using (FileStream stream = new FileStream(Folderpath, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
           
                       // Paragraph k = new Paragraph("Your PDF ");            
                       // pdfDoc.Add(k);
                        
                        pdfDoc.Close();
                        stream.Close();
                 
    
    
                    }
