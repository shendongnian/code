    public class TextBlock
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public override ToString() => $"Text block {Id} = {Text}";
    }
