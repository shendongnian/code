    using (Document document = new Document()) {
      PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
      document.Open();
      try {
        StringReader sr = new StringReader(htmlString);
        XMLWorkerHelper.GetInstance().ParseXHtml(
          writer, document, sr
        );          
      }
      catch (Exception e) {
        throw;
      }
    }
