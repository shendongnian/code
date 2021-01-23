    Dictionary<string, Exception> errors = 
      new Dictionary<string, Exception>();
    document.Open();
    PdfContentByte cb = writer.DirectContent;
    foreach (string filePath in testList) {
      try {
        PdfReader reader = new PdfReader(filePath);
        int pages = reader.NumberOfPages;
        for (int i = 0; i < pages; ) {
          document.NewPage();
          PdfImportedPage page = writer.GetImportedPage(reader, ++i);
          cb.AddTemplate(page, 0, 0);
        }
      }
    // **may** be PDF spec, but not supported by iText      
      catch (iTextSharp.text.exceptions.UnsupportedPdfException ue) {
        errors.Add(filePath, ue);
      }
    // invalid according to PDF spec
      catch (iTextSharp.text.exceptions.InvalidPdfException ie) {
        errors.Add(filePath, ie);
      }
      catch (Exception e) {
        errors.Add(filePath, e);
      }
    }
    if (errors.Keys.Count > 0) {
      document.NewPage();
      foreach (string key in errors.Keys) {
        document.Add(new Paragraph(string.Format(
          "FILE: {0}\nEXCEPTION: [{1}]: {2}",
          key, errors[key].GetType(), errors[key].Message
        )));
      }
    }
