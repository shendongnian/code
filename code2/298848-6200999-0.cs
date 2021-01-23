    public static AnchorStyles Parse(string str)
    {
        var style = AnchorStyles.None;
        foreach (var styleStr in str.Split(';'))
        {
            AnchorStyles parsed;
            if(!Enum.TryParse(styleStr, true, out parsed))
            {
                //Handle bad value here
            }
            else
            {
                style |= parsed;
            }
        }
        return style;
    }
