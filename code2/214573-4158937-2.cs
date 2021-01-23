    public class BrushFromArgbExtension : MarkupExtension
    {
        public BrushFromArgbExtension() { }
        public BrushFromArgbExtension(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }
        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new SolidColorBrush(Color.FromArgb(A, R, G, B));
        }
    }
