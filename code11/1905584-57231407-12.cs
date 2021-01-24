    private PrivateFontCollection SafeLoadFontFamily(IEnumerable<string> fontList)
    {
        if (fontList == null) return null;
        var fontCollection = new PrivateFontCollection();
        foreach (string fontFile in fontList)
        {
            if (!File.Exists(fontFile)) continue;
            byte[] fontBytes = File.ReadAllBytes(fontFile);
            var fontData = Marshal.AllocCoTaskMem(fontBytes.Length);
            Marshal.Copy(fontBytes, 0, fontData, fontBytes.Length);
            fontCollection.AddMemoryFont(fontData, fontBytes.Length);
        }
        return fontCollection;
    }
