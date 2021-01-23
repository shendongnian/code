    using System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary
    public byte[] ToBytes(string hex)
    {
        var shb = SoapHexBinary.Parse(hex);
        return shb.Value;
    }
    public void TestConvert()
    {
        byte[] someBytes = ToBytes("83C8BB02E96F2383870CC1619B6EC");
    }
