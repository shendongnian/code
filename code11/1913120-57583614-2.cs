    private struct MyPixel
    {
        public Point Coord { get; set; }
        public Color Rgb { get; set; }
        public float Rfraction
        {
            get { return Rgb.R / (float)(Rgb.R + Rgb.G + Rgb.B); }
        }
        public float Bfraction
        {
            get { return Rgb.B / (float)(Rgb.R + Rgb.G + Rgb.B); }
        }
    }
