    public class CheckedListBoxItem
    {
        public CheckedListBoxItem(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
        public CheckState CheckState { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
