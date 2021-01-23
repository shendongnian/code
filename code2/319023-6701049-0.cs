    using System.Drawing;
    class ShortColor
    {
        public bool Alpha { get; set; }
        public byte Red   { get; set; }
        public byte Green { get; set; }
        public byte Blue  { get; set; }
        public ShortColor(short value)
        {
             this.Alpha = (value & 0x8000) > 0;
             this.Red = (byte)((value & 0x7C64) >> 10);
             this.Green = (byte)((value & 0x3E0) >> 5);
             this.Blue = (byte)((value & 0x001F));
        }
        public ShortColor(Color color)
        {
             this.Alpha = color.A != 0;
             this.Red = (byte)(color.R / 8);
             this.Green = (byte)(color.G / 8);
             this.Blue = (byte)(color.B / 8);
        }
        public static explicit operator Color(ShortColor shortColor)
        {
             return Color.FromArgb(
                 shortColor.Alpha ? 255 : 0,
                 shortColor.Red * 8,
                 shortColor.Green * 8,
                 shortColor.Blue * 8
             );
        }
    }
