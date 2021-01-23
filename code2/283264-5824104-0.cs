    System.Drawing.Image img = System.Drawing.Bitmap.FromFile("file");
    System.Drawing.Imaging.ColorPalette palette = img.Palette;
    foreach (Color color in palette.Entries)
    {
      //...
    }
