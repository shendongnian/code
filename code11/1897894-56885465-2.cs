    public enum PdfOrientation { Landscape, Portrait };
    public class PdfGlobalOptions
    {
        public float? MarginTop { get; set; }
        public float? MarginLeft { get; set; }
        public float? MarginBottom { get; set; }
        public float? MarginRight { get; set; }
        public float? PageWidth { get; set; } 
        public float? PageHeight { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public float? HeaderSpacing { get; set; }
        public PdfOrientation Orientation { get; set; }
        public float? FooterSpacing { get; set; }
    }
