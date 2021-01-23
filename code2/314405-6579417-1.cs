    public class OutputFormats
    {
        public string Value { get; private set; }
        public string Filename { get; private set; }
        public int ID { get; private set; }
        private OutputFormats() { }
        public static readonly Pdf = new OutputFormats() { Value = "Pdf", Filename  = "*.PDF", ID = 1 };
        public static readonly Jpg = new OutputFormats() { Value = "Jpg", Filename = "*.JPG", ID = 2 };
    }
