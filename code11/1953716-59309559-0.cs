    /// <summary>
    /// A detected argument in a format string
    /// </summary>
    public class DetectedFormat
    {
        public DetectedFormat(int position, string format)
        {
            Position = position;
            Format = format;
        }
        public int Position { get; set; }
        public string Format { get; set; }
    }
    /// <summary>
    /// Implements IFormattable. Used to collect format placeholders
    /// </summary>
    public class FormatDetector: IFormattable
    {
        private int _position;
        List<DetectedFormat> _list;
        public FormatDetector(int position, List<DetectedFormat> list)
        {
            _position = position;
            _list = list;
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            DetectedFormat detectedFormat = new DetectedFormat(_position, format);
            _list.Add(detectedFormat);
            // Return the placeholder without the format
            return "{" + _position + "}";
        }
    }
