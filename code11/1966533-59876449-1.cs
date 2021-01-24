        public class OutputSettings
    {
        public static readonly OutputSettings Default = new OutputSettings(Encoding.UTF8, null, "yyyyMMdd", "hh:mm:ss", ".", "", "y", "n", ',', true, "", null);
        //I am immutable
        public OutputSettings(CultureInfo culture) : this(
            Encoding.UTF8,
            null,
            culture.DateTimeFormat.ShortDatePattern,
            culture.DateTimeFormat.LongTimePattern,
            culture.NumberFormat.NumberDecimalSeparator,
            culture.NumberFormat.NumberGroupSeparator,
            "y",
            "n",
            ',',
            true,
            "",
            null)
        {
        }
        public OutputSettings(
            Encoding encoding,
            Version ioVersion,
            string dateFormat,
            string timeFormat,
            string decimalSeperator,
            string thousandSeperator,
            string yesString,
            string noString,
            char columnseperator,
            bool writeinquotes,
            string outputFolder,
            IResourceHandler resourceHandler)
        {
            Encoding = encoding;
            IOVersion = ioVersion;
            DateFormat = dateFormat;
            TimeFormat = timeFormat;
            DecimalSeperator = decimalSeperator;
            ThousandSeperator = thousandSeperator;
            YesString = yesString;
            NoString = noString;
            ColumnSeparator = columnseperator;
            Writeinquotes = writeinquotes;
            OutputFolder = outputFolder;
            ResourceHandler = resourceHandler;
        }
        public IResourceHandler ResourceHandler { get; }
        public Encoding Encoding { get; }
        public Version IOVersion { get; }
        public string DateFormat { get; }
        public string TimeFormat { get; }
        public string DateTimeFormat => DateFormat + " " + TimeFormat;
        public string DecimalSeperator { get; }
        public string ThousandSeperator { get; }
        public string DecimalFormat => GetDecimalFormat(2);
        public string YesString { get; }
        public string NoString { get; }
        private char _columnseperator;
        public char ColumnSeparator
        {
            get
            {
                return _columnseperator;
            }
            private set
            {
                if (value != ',' && value != ';')
                    throw new ArgumentException(Localization.Resources.StaticTranslationResource.IO_SEPARATOR_MUSS_COMMA_ODER_SEMICOLON_SEIN);
                _columnseperator = value;
            }
        }
        public bool Writeinquotes { get; }
        public string OutputFolder { get; set; }
        public string GetDecimalFormat(int precision)
        {
            if (precision < 0)
                throw new ArgumentException(Localization.Resources.StaticTranslationResource.OUTPUT_ANZAHL_DER_STELLEN_DARF_NICHT_NEGATIV_SEIN, nameof(precision));
            var sb = new StringBuilder($"#{ThousandSeperator}##0{DecimalSeperator}");
            if (precision == 0)
            {
                sb.Append('#');
            }
            else
            {
                for (int i = 0; i < precision; i++)
                {
                    sb.Append('0');
                }
            }
            return sb.ToString();
        }
    }
