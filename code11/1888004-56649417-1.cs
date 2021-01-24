    String sourceFile = @"SOURCE.pdf";
    String imagePath = @"extract\";
    String imageBaseName = "SOURCE-";
    Directory.CreateDirectory(imagePath);
    using (PdfReader pdfReader = new PdfReader(sourceFile))
    {
        PdfReaderContentParser parser = new PdfReaderContentParser(pdfReader);
        for (var i = 1; i <= pdfReader.NumberOfPages; i++)
        {
            SimpleMixedExtractionStrategy listener = new SimpleMixedExtractionStrategy(imagePath, imageBaseName + i);
            parser.ProcessContent(i, listener);
            String text = listener.GetResultantText();
            Console.Write("Text of page {0}:\n---\n{1}\n\n", i, text);
        }
    }
