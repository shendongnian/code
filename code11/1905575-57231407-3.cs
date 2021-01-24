    string fontsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts");
    var fontFiles = Directory.GetFiles(fontsPath).OrderBy(s => s).ToList();
    fontFiles.ForEach(f => {
        using (var fontCollection = new PrivateFontCollection())
        {
            fontCollection.AddFontFile(f);
            Console.WriteLine(fontCollection.Families[0].Name);
        };
    });
