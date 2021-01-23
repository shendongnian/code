    public class FileStreamEx : System.IO.FileStream
    {
        private bool _deleteOnDispose = false;
        public FileStreamEx(string path, ....) : base(path, ...) { }
        public bool DeleteOnDispose
        {
            get { return _deleteOnDispose; }
            set { _deleteOnDispose = value; }
        }
        protected override void Dispose(bool disposing)
        {
            if (_deleteOnDispose)
            {
                System.IO.File.Delete(this.Name);
            }
            base.Dispose(disposing);
        }
    }
