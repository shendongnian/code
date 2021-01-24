    // Common interface
    public interface IThing { }
    public class Thing : IThing
    {
        public Thing(int number) { Number = number; }
        public int Number { get; }
    }
    public class Thingy : IThing
    {
        public Thingy(string text) { Text = text; }
        public string Text { get; }
    }
