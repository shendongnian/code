    public sealed class DropDownItem
    {
        public string Value { get; set; }
        public Image Image { get; set; }
        public DropDownItem()
            : this("")
        { }
        public DropDownItem(string val)
        {
            Value = val;
            Image = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(Image))
            {
                using (Brush b = new SolidBrush(Color.FromName(val)))
                {
                    g.DrawRectangle(Pens.White, 0, 0, Image.Width, Image.Height);
                    g.FillRectangle(b, 1, 1, Image.Width - 1, Image.Height - 1);
                }
            }
        }
        public override string ToString()
        {
            return Value;
        }
    }
