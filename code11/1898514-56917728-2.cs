    using (var zipfile = System.IO.Compression.ZipFile.OpenRead(inzip))
    using (var reader = new System.IO.StreamReader(zipfile.Entries.Where(x => x.Name.Equals(infile, StringComparison.InvariantCulture)).FirstOrDefault().Open()))
    {
        dataout = new string(reader.ReadToEnd().ToArray());
    }
