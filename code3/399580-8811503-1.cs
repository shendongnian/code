    byte[] content;
    using (var ms = new MemoryStream())
    {
        using (var writer = new StreamWriter(ms))
        {
            foreach (var movieName in MovieList)
                writer.WriteLine(movieName);
        }
        
        content = ms.ToArray();
    }
    return File(content, "text/csv", "demo.csv");
