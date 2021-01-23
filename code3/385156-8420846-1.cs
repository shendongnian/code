    PdfReader reader = new PdfReader(INPUT_FILE);
    using (MemoryStream ms = new MemoryStream()) {
      using (PdfStamper stamper = new PdfStamper(reader, ms)) {
        // add your content
      }
      using (FileStream fs = new FileStream(
        OUTPUT_FILE, FileMode.Create, FileAccess.ReadWrite))
      {
        PdfEncryptor.Encrypt(
          new PdfReader(ms.ToArray()),
          fs,
          null,
          System.Text.Encoding.UTF8.GetBytes("ownerPassword"),
          PdfWriter.ALLOW_PRINTING
              | PdfWriter.ALLOW_COPY,
          true
        );
      }  
    }
