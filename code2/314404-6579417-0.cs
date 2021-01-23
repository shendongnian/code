    public class OutputFormats
    {
        public readonly string Value;
        public readonly string Filename;
        public readonly int ID;
        private OutputFormats(string value, string filename, int id)
        {
            this.Value = value;
            this.Filename = filename;
            this.ID = id;
        }
        public static readonly Pdf = new OutputFormats("Pdf", "*.PDF", 1);
        public static readonly Jpg = new OutputFormats("Jpg", "*.JPG", 2);
    }
