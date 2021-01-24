    public class Creature
    {
        public IList<string> Dragon { get; set; }
        public IList<string> Wolf { get; set; }
    }
    public class Size
    {
        public Creature Creature { get; set; }
        public IList<string> Building { get; set; }
    }
    public class Example
    {
        public Size Size { get; set; }
    }
