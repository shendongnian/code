    StreamWriter writer;
    using(var stream = new FileStream(name))
    {
        writer = new StreamWriter(stream);
    }
    writer.Write(1); // <= writnig to closed stream here.
    writer.Dispose();
