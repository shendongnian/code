    public static byte[] UnzipSingleEntry(byte[] zipped)
    {
        using (var memoryStream = new MemoryStream(zipped))
        {
            using (var archive = new ZipArchive(memoryStream))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    using (var entryStream = entry.Open())
                    {
                        using (var reader = new BinaryReader(entryStream))
                        {
                            return reader.ReadBytes((int)entry.Length);
                        }
                    }
                }
            }
        }
        return null; // To quiet my compiler
    }
