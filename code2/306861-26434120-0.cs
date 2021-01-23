    Color percentToColor(float percent)
    {
        if (percent<0 || percent>1) { return Color.Black; }
        int r, g;
        if (percent<0.5)
        {
            r=255;
            g = (int)(255*percent/0.5);  //closer to 0.5, closer to yellow (255,255,0)
        }
        else
        {
            g=255;
            r = 255 - (int)(255*(percent-0.5)/0.5); //closer to 1.0, closer to green (0,255,0)
        }
        return Color.FromArgb(r, g, 0);
    }
