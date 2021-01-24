    // Field/Class object
    PrivateFontCollection fontCollection = null;
    // (...)
    // Somewhere else
    string fontsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts");
    var fontFiles = Directory.GetFiles(fontsPath);
    fontCollection = UnsafeLoadFontFamily(fontFiles);
    // Or...
    fontCollection = SafeLoadFontFamily(fontFiles);
    fontCollection.Families.OrderBy(f => f.Name).ToList().ForEach(font =>
    {
        Console.WriteLine(font.GetName(0));
    });
