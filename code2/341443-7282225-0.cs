    PdfReader pdfReader = null;
    PdfStamper pdfStamper = null;
    
    // Open the PDF file to be signed
    pdfReader = new PdfReader(this.signFile.FullName);
    
    // Output stream to write the stamped PDF to
    using (FileStream outStream = new FileStream(targetFilename, FileMode.Create))
    {
      try
      {
        // Stamper to stamp the PDF with a signature
        pdfStamper = new PdfStamper(pdfReader, outStream);
    
        // Load signature image
        iTextSharp.text.Image sigImg = iTextSharp.text.Image.GetInstance(SIGNATURE_IMAGE_PATH);
    
        // Scale image to fit
        sigImg.ScaleToFit(MAX_WIDTH, MAX_HEIGHT);
        
        // Set signature position on page
        sigImg.SetAbsolutePosition(POS_X, POS_X);
    
        // Add signatures to desired page
        PdfContentByte over = pdfStamper.GetOverContent(PAGE_NUM_TO_SIGN);
        over.AddImage(sigImg);
      }
      finally
      {
        // Clean up
        if (pdfStamper != null)
          pdfStamper.Close();
    
        if (pdfReader != null)
          pdfReader.Close();
      }
    }
