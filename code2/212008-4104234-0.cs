    class ColorWrapper
    {
        public Color Color  { get; set; }
        public byte Hue
        {
            get { return this.Color.Hue; } //or however this is calculated
    }
