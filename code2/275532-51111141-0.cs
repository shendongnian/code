    var newAliasForPalette = bmp.Palette; // Palette loaded from graphic device
    for (int i = 0; i < 256; i++)
    {
        newAliasForPalette.Entries[i] = myColor[i];
    }
    bmp.Palette = newAliasForPalette; // Palette data wrote back to the graphic device
