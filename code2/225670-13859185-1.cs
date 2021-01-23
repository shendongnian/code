    private const float ItalicPaddingFactor = 0.5f;
    ...
    float overhangPadding = (gdiHeight / 6.0f);
    //NOTE: proper margins for TextFormatFlags.LeftAndRightPadding flag
    //int leftMargin = (int)Math.Ceiling(overhangPadding);
    //int rightMargin = (int)Math.Ceiling(overhangPadding * (2 + ItalicPaddingFactor));
    //NOTE: proper margins for TextFormatFlags.GlyphOverhangPadding flag
    int leftMargin = (int)Math.Ceiling(overhangPadding);
    int rightMargin = (int)Math.Ceiling(overhangPadding * (1 + ItalicPaddingFactor));
    Size sizeOverhangPadding = TextRenderer.MeasureText(e.Graphics, "ABC", font, Size.Empty, TextFormatFlags.GlyphOverhangPadding);
    Size sizeNoPadding = TextRenderer.MeasureText(e.Graphics, "ABC", font, Size.Empty, TextFormatFlags.NoPadding);
    int overallPadding = (sizeOverhangPadding.Width - sizeNoPadding.Width);
