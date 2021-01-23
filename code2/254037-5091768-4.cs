    class StandardColorComparer : IComparer<Color>
    {
        // Methods
        public int Compare(Color color, Color color2)
        {
            if (color.A < color2.A)
            {
                return -1;
            }
            if (color.A > color2.A)
            {
                return 1;
            }
            if (color.GetHue() < color2.GetHue())
            {
                return -1;
            }
            if (color.GetHue() > color2.GetHue())
            {
                return 1;
            }
            if (color.GetSaturation() < color2.GetSaturation())
            {
                return -1;
            }
            if (color.GetSaturation() > color2.GetSaturation())
            {
                return 1;
            }
            if (color.GetBrightness() < color2.GetBrightness())
            {
                return -1;
            }
            if (color.GetBrightness() > color2.GetBrightness())
            {
                return 1;
            }
            return 0;
        }
    }
    
    class SystemColorComparer : IComparer<Color>
    {
        // Methods
        public int Compare(Color color, Color color2)
        {
            return string.Compare(color.Name, color2.Name, false, CultureInfo.InvariantCulture);
        }
    }
