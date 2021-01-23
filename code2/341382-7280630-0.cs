    InstalledFontCollection ifc = new InstalledFontCollection();
    for (int i = 0; i < ifc.Families.Length; i++)
        {
             if (ifc.Families[i].IsStyleAvailable(FontStyle.StrikeOut))
             {
                 //add particular font with this family to your "font selector"
             }
        }
