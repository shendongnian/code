    InstalledFontCollection installedFontCollection = new InstalledFontCollection();
    // Get the array of FontFamily objects.
    fontFamilies = installedFontCollection.Families;
    
    // The loop below creates a large string that is a comma-separated
    // list of all font family names.
    
    int count = fontFamilies.Length;
    for (int j = 0; j < count; ++j)
    {
        familyName = fontFamilies[j].Name;
        familyList = familyList + familyName;
        familyList = familyList + ",  ";
    }
