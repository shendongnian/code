    // Usings:
    //  using System.Runtime.Serialization;
    //  using System.Runtime.Serialization.Formatters.Binary;
    var map = GenerateMap();
    IFormatter formatter = new BinaryFormatter();
    byte[] serbytes;
    using (var ms = new MemoryStream())
    {
        fmt.Serialize(ms, map);
        serbytes = ms.ToArray();
    }
