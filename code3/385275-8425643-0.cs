    // Save key and IV
    using (var rijndael = new RijndaelManaged())
    using (var writer = new BinaryWriter(File.Create("yyy.dat")))
    {
        writer.Write(rijndael.Key, 0, 32);
        writer.Write(rijndael.IV, 0, 16);
    }
    // Restore key and IV
    using (var rijndael = new RijndaelManaged())
    using (var reader = new BinaryReader(File.OpenRead("yyy.dat")))
    {
        rijndael.Key = reader.ReadBytes(32);
        rijndael.IV = reader.ReadBytes(16);
    }
