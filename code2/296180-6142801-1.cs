    #if GDI
    100    /// <summary>
    101    /// Create the font image using GDI+ functionality.
    102    /// </summary>
    103    void CreateGdiFontImage(XFont font, XPdfFontOptions options/*, XPrivateFontCollection privateFontCollection*/)
    104    {
    105      System.Drawing.Font gdiFont = font.RealizeGdiFont();
    106      NativeMethods.LOGFONT logFont;
    ...
