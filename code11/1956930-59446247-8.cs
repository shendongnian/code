    public abstract class TextBase
    {
        public const string LineSeparator = "\n";
        public const string ParagraphSeparator = "\r";
        public const string ParagraphGroupSeparator = "\v";
        public abstract string Text { get; set; }
    }
