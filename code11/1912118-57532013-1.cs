    public void UpdateRed(float newRed)
    {
        red = newRed;
        UpdateHairColor();
    }
    public void UpdateGreen(float newGreen)
    {
        green = newGreen;
        UpdateHairColor();
    }
    public void UpdateBlue(float newBlue)
    {
        blue = newBlue;
        UpdateHairColor();
    }
    public void UpdateHairColor()
    {
         hairColor = new Color(red/maxColor, green/maxColor, blue/maxColor);
    }
