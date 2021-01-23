    public class DeleteAfterReadingStream : FileStream
    {
        public DeleteAfterReadingStream(string path)
            : base(path, FileMode.Open)
        {
        }
    
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (File.Exists(Name))
                File.Delete(Name);
        }
    }
