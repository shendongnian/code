    public void Print(string pdfFilePath)
    {
          if (!File.Exists(pdfFilePath))
              throw new FileNotFoundException("No such file exists!", pdfFilePath);
    
          // Create a Pdf Document Processor instance and load a PDF into it.
          PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor();
          documentProcessor.LoadDocument(pdfFilePath);
    
          if (documentProcessor != null)
          {
              PrinterSettings settings = new PrinterSettings();
    
              //var paperSizes = settings.PaperSizes.Cast<PaperSize>().ToList();
              //PaperSize sizeCustom = paperSizes.FirstOrDefault<PaperSize>(size => size.Kind == PaperKind.Custom); // finding paper size
    
              settings.DefaultPageSettings.PaperSize = new PaperSize("Label", 400, 600);
    
              // Print pdf
              documentProcessor.Print(settings);
          }
    }
