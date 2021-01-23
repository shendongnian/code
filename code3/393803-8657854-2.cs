    using System.Drawing.Text;
    InstalledFontCollection fontsCollection = new InstalledFontCollection();
    FontFamily[] fontFamilies = fontsCollection.Families;
    List<string> fonts = new List<string>();   
    foreach (FontFamily font in fontFamilies)
    {
       fonts.Add(font.Source);
    }
