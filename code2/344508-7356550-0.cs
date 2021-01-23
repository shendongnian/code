    IEnumerable<TextLocation> TextLocations = ...;
    internal class TextLocation
    {
        public RectF BoundingBox { get; set; }  //this is relative to the textbox
        public TextWord TextWord { get; set; }
    }
    internal class TextWord
    {
        public string Text { get; set; }
        public IEnumerable<LetterInfo> Letters { get; set; }
    }
    internal class LetterInfo
    {
        public char Letter { get; set; }
        public float left { get; set; }  //these would be relative to the bounding box
        public float right { get; set; } //not to the textbox
    }
