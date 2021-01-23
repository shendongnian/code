    public void ConvertTiffToPdf(string sourceTiff, string destPdf)
    {
        using (FileStream dest = new FileStream(destPdf, FileMode.Create)) {
            FileSystemImageSource source new FileSystemImageSource(sourceTiff, true); // convert all pages
            PdfEncoder encoder = new PdfEncoder();
            encoder.Save(dest, source, null);
        }
    }
