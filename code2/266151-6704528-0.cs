        //xls to pdf        
        Workbook workbook = new Workbook();
        workbook.LoadFromFile("sample.xlsx", ExcelVersion.Version2007);
        PdfConverter pdfConverter = new PdfConverter(workbook);
        PdfDocument pdfDocument = new PdfDocument();
        pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape;
        pdfDocument.PageSettings.Width = 970;
        pdfDocument.PageSettings.Height = 850;
        PdfConverterSettings settings = new PdfConverterSettings();
        settings.TemplateDocument = pdfDocument;
        pdfDocument = pdfConverter.Convert(settings);
        pdfDocument.SaveToFile("test.pdf");
        
        //doc to pdf
        Document doc = new Document();
        doc.LoadFromFile("sample.docx", FileFormat.Docx);
        doc.SaveToFile("test.pdf", FileFormat.PDF);
