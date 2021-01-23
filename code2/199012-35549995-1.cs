    static public int MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
    {
        System.Drawing.StringFormat format  = new System.Drawing.StringFormat ();
        System.Drawing.RectangleF   rect    = new System.Drawing.RectangleF(0, 0, 1000, 1000);
        var ranges  = new System.Drawing.CharacterRange(0, text.Length);
        System.Drawing.Region[] regions = new System.Drawing.Region[1];
    
        format.SetMeasurableCharacterRanges (new[] {ranges});
    
        regions = graphics.MeasureCharacterRanges (text, font, rect, format);
        rect    = regions[0].GetBounds (graphics);
    
        return (int)(rect.Right + 1.0f);
    }
