    public static Color FromTransparentWithWhiteBG(Color A)
    {
        Color background = Colors.White;
        R_c := ceiling(A.R * A.A) + ceiling (background.R * (1 - A.A));
        G_c := ceiling(A.G * A.A) + ceiling (background.G * (1 - A.A));
        B_c := ceiling(A.B * A.a) + ceiling (background.B * (1 - A.A));
        return Color.FromARGB(1, R_c, G_c, B_c);
    }
