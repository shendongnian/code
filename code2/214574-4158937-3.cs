    public class FromArgbExtension : MarkupExtension
    {
        public FromArgbExtension() { }
        public FromArgbExtension(byte a, byte r, byte g, byte b)
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
            return Color.FromArgb(A, R, G, B);
        }
    }
