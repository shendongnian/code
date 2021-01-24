    public class Document
    {
        public string Encoding { get; set; }
        private string Filename { get; set; }
        public string SafeFilename => string.IsNullOrEmpty(Filename) ? "NoFilenameSupplied" : Filename;
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
