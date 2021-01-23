    static class ColorExtension
    {
        public static Color ChangeG(Color this color,byte g) 
        {
            return Color.FromArgb(color.A,color.R,g,color.B);
        }
    }
