    public class JourneyItem {
        // more stuff
        public bool Selected { get; set; }
        public Color BackgroundColor => Selected ? Color.Blue : Color.Gray;
        public Color TextColor => Selected ? Color.White : Color.Black;
    }
