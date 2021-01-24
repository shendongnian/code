    //  As a field
    List<string> fontNames = new List<string>();
     // Inside a method
    var fontFiles = Directory.GetFiles(fontsPath).ToList();
    fontFiles.ForEach(f => {
        using (var fontCollection = new PrivateFontCollection())
        {
            fontCollection.AddFontFile(f);
            fontNames.Add(fontCollection.Families[0].Name);
        };
    });
    fontNames = fontNames.OrderBy(s => s).ToList();
    fontNames.ForEach(familyName => Console.WriteLine(familyName));
