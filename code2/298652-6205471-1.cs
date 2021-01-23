    public static Color FromTransparentWithWhiteBG(Color A)
    {
            var background = Color.White;
            var R_c = (Int32)(Math.Ceiling((Double)A.R * A.A) + Math.Ceiling ((Double)background.R * (1 - A.A)));
            var G_c = (Int32)(Math.Ceiling((Double)A.G * A.A) + Math.Ceiling ((Double)background.G * (1 - A.A)));
            var B_c = (Int32)(Math.Ceiling((Double)A.B * A.a) + Math.Ceiling ((Double)background.B * (1 - A.A)));
            return Color.FromArgb(1, R_c, G_c, B_c);
    }
