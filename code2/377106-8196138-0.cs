    public class Section
    {
        public String Head { get; set; }
        private readonly List<string> _subHead = new List<string>();
        private readonly List<string> _content = new List<string>();
    
        // Note: fix to case to conform with .NET naming conventions
        public IList<string> SubHead { get { return _subHead; } }
        public IList<string> Content { get { return _content; } }
    }
