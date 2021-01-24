    public class downloadListener : IDownloadListener
    {
    
        public IntPtr Handle => throw new NotImplementedException();
    
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    
        public void OnDownloadStart(string url, string userAgent, string contentDisposition, string mimetype, long contentLength)
        {
            // code listen here
        }
    }
