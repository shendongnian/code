    public static Color FromTransparentWithWhiteBG(Color A)
    {
        // Assuming Alpha is a value between 0 and 254...
        var aFactor = (A.A/254);
        var bgAFactor = (1-(A.A/254));
        var background = Color.White;
        var R_c = (Int32)(Math.Ceiling((Double)A.R * aFactor) + Math.Ceiling ((Double)background.R * (1 - bgAFactor )));
        var G_c = (Int32)(Math.Ceiling((Double)A.G * aFactor) + Math.Ceiling ((Double)background.G * (1 - bgAFactor )));
        var B_c = (Int32)(Math.Ceiling((Double)A.B * aFactor) + Math.Ceiling ((Double)background.B * (1 - bgAFactor )));
        return Color.FromArgb(1, R_c, G_c, B_c);
    }
