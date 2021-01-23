    var path = "YourSolutionDirectoryPath";
    using (var engine = new TesseractEngine(path + Path.DirectorySeparatorChar + "tessdata", "fra", EngineMode.TesseractAndCube))
    {
        using (var img = Pix.LoadFromFile(sourceFilePath))
        {
            using (var page = engine.Process(img))
            {
                var text = page.GetText();
                // text variable contains a string with all words found
            }
        }
    }
