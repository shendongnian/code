    public class TextBlock
    {
        public string Text { get; set; }
        public Grid Grid { get; set; }
        public TextBlock(Grid grid)
        {
            Grid = grid;
        }
    }
