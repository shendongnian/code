    public interface IServicePdf
    {
        object GeneratePDF(string url, string filename);
        PdfGlobalOptions Options { set; get; }
    }
