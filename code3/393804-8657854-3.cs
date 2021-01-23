    using System.Drawing.Text;
    using (InstalledFontCollection fontsCollection = new InstalledFontCollection())
    {
        FontFamily[] fontFamilies = fontsCollection.Families;
        List<string> fonts = new List<string>();   
        foreach (FontFamily font in fontFamilies)
        {
           fonts.Add(font.Source);
        }
    }
