    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(path))
    {
        List<string> annotations = Build(loadedDocument);
    }
    public class PdfLoadedDocument : IDisposable
    {
        public void Close()
        {
    
        }
        public void Save()
        {
    
        }
    
        public void Dispose()
        {
            Save();
            Close();
        }
    }
