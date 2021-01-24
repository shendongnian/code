    // Usings:
    //  using System.IO.Compression;
    //  using System.Runtime.Serialization;
    //  using System.Runtime.Serialization.Formatters.Binary;
    var map = GenerateMap();
    IFormatter formatter = new BinaryFormatter();
    byte[] serbytes;
    using (var ms = new MemoryStream)
    {
        using (var cmp = new GZipStream(ms, CompressionLevel.Optimal, true))
        {
            fmt.Serialize(ms, map);
        }
        serbytes = ms.ToArray();
    }
