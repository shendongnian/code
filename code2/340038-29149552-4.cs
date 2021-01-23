    public void SelectPages(string inputPdf, string pageSelection, string outputPdf)
    {
        using (PdfReader reader = new PdfReader(inputPdf))
        {
            reader.SelectPages(pageSelection);
            using (PdfStamper stamper = new PdfStamper(reader, File.Create(outputPdf)))
            {
                stamper.Close();
            }
        }
    }
