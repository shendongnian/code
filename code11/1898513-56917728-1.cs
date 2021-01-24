    using (var zipfile = System.IO.Compression.ZipFile.OpenRead(inzip))
    {
        dataout = new string(
                (new System.IO.StreamReader(
                 zipfile
                 .Entries.Where(x => x.Name.Equals(infile, StringComparison.InvariantCulture))
                 .FirstOrDefault()
                 .Open())
                 .ReadToEnd())
                 .ToArray());
    }
