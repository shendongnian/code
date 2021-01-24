    private unsafe PrivateFontCollection UnsafeLoadFontFamily(IEnumerable<string> fontList)
    {
        if (fontList.Length == 0) return null;
        var fontCollection = new PrivateFontCollection();
        foreach (string fontFile in fontList)
        {
            if (!File.Exists(fontFile)) continue;
            byte[] fontData = File.ReadAllBytes(fontFile);
            fixed (byte* fontPtr = fontData)
            {
                fontCollection.AddMemoryFont(new IntPtr(fontPtr), fontData.Length);
            }
        }
        return fontCollection;
    }
