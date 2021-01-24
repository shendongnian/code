    using (PdfReader reader = new PdfReader(@"EVERMOTION ARCHMODELS VOL.78.pdf"))
    {
        PdfReaderContentParser parser = new PdfReaderContentParser(reader);
        ImageWithTitleRenderListener listener = new ImageWithTitleRenderListener(@"extract\EVERMOTION ARCHMODELS VOL.78-{0:D3}.{1}");
        for (var i = 1; i <= reader.NumberOfPages; i++)
        {
            parser.ProcessContent(i, listener);
        }
    }
