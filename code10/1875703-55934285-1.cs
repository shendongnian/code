    public class Document
    {
        public string Encoding { get; set; }
        public string Filename { get; set; }
        public string SafeFilename => string.IsNullOrEmpty(Filename) ? "NoFilenameSupplied" : Filename;
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
