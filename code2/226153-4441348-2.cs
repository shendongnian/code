    public class ImageFileProcessor : IFileProcessor
    {
        public IEnumerable<string> FileExtensions 
        {
            get {return new[]{"jpg", "gif", "png"};}
        }
        public void Process(string fileName) 
        {
            // Process Image file type
        }
    }
