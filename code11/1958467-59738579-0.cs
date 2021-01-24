    Directory.CreateDirectory(@"extract\");
    using (PdfReader reader = new PdfReader(@"Moving to Microsoft Visual Studio 2010 ebook.pdf"))
    using (PdfDocument pdfDocument = new PdfDocument(reader))
    {
        IEventListener strategy = new ImageRenderListener(@"extract\Moving to Microsoft Visual Studio 2010 ebook-i7-{0}.{1}");
        PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
        for (var i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
        {
            parser.ProcessPageContent(pdfDocument.GetPage(i));
        }
    }
