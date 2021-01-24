    public class ScanInfo
    {
        public int JobControl { get; set; } = 0;
        public int Sheet { get; set; } = 0;
        public DateTime Stamp { get; set; } = DateTime.Now;
        public override string ToString() => $"*{JobControl}-{Sheet}*";
    }
