    using System.Drawing.Text;
    InstalledFontCollection fonts = new InstalledFontCollection();
    foreach (FontFamily ff in fonts.Families)
    {
        if (ff.IsStyleAvailable(FontStyle.Regular))
            Items.Add(ff.Name);
    }
