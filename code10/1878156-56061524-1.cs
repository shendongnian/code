    public Color ToWhiteExceptYellow(Color c, int range)
    {
        float hueC = c.GetHue();
        float e = 1.5f * range;
        float hueY = Color.Yellow.GetHue();
        float delta = hueC - hueY;
        bool ok = (Math.Abs(delta) < e);
        return ok ? c : Color.White;
    }
