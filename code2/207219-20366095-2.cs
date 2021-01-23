     using (var reader = new PdfReader(@"C:\Input.pdf"))
     {
        using (var fileStream = new FileStream(@"C:\Output.pdf", FileMode.Create, FileAccess.Write))
        {
           var document = new Document(reader.GetPageSizeWithRotation(1));
           var writer = PdfWriter.GetInstance(document, fileStream);
    
           document.Open();
    
           for (var i = 1; i <= reader.NumberOfPages; i++)
           {
              document.NewPage();
    
              var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
              var importedPage = writer.GetImportedPage(reader, i);
    
              var contentByte = writer.DirectContent;
              contentByte.BeginText();
              contentByte.SetFontAndSize(baseFont, 12);
    
              var multiLineString = "Hello,\r\nWorld!".Split('\n');
    
              foreach (var line in multiLineString)
              {
                 contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, line, 200, 200, 0);
              }
    
              contentByte.EndText();
              contentByte.AddTemplate(importedPage, 0, 0);
           }
    
           document.Close();
           writer.Close();
        }
     }
