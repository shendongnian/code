static void Main(string[] args)
{
    var keySizeInBits = 1024;
    var privateKeyFileName = "privatekey.pem";
    var selfSignedCertificateName = "privatekey.pfx";
    var numberOfDaysValid = 1825;
    var passphrase = "RGliXtaLkENste";
    using (var rsa = RSA.Create(keySizeInBits))
    {
        using (var privateFile = File.CreateText(privateKeyFileName))
        {
            ExportPrivateKey(rsa, privateFile);
        }
        var selfSignedServerCerticate = BuildSelfSignedServerCertificate(rsa, numberOfDaysValid, passphrase);
        using (FileStream fs = new FileStream(selfSignedCertificateName, FileMode.Create, FileAccess.Write))
        {
            fs.Write(selfSignedServerCerticate, 0, selfSignedServerCerticate.Length);
        }
    }
}
private static void ExportPrivateKey(RSA rsa, TextWriter outputStream)
{
    var parameters = rsa.ExportParameters(true);
    using (var stream = new MemoryStream())
    {
        var writer = new BinaryWriter(stream);
        writer.Write((byte)0x30); // SEQUENCE
        using (var innerStream = new MemoryStream())
        {
            var innerWriter = new BinaryWriter(innerStream);
            EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
            EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
            EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
            EncodeIntegerBigEndian(innerWriter, parameters.D);
            EncodeIntegerBigEndian(innerWriter, parameters.P);
            EncodeIntegerBigEndian(innerWriter, parameters.Q);
            EncodeIntegerBigEndian(innerWriter, parameters.DP);
            EncodeIntegerBigEndian(innerWriter, parameters.DQ);
            EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);
            var length = (int)innerStream.Length;
            EncodeLength(writer, length);
            writer.Write(innerStream.GetBuffer(), 0, length);
        }
        var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();
        outputStream.WriteLine("-----BEGIN RSA PRIVATE KEY-----");
        // Output as Base64 with lines chopped at 64 characters
        for (var i = 0; i < base64.Length; i += 64)
        {
            outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
        }
        outputStream.WriteLine("-----END RSA PRIVATE KEY-----");
    }
}
private static byte[] BuildSelfSignedServerCertificate(RSA rsa, int numberOfDaysValid, string password)
{
    var sanBuilder = new SubjectAlternativeNameBuilder();
    sanBuilder.AddIpAddress(IPAddress.Loopback);
    sanBuilder.AddIpAddress(IPAddress.IPv6Loopback);
    sanBuilder.AddDnsName("localhost");
    sanBuilder.AddDnsName(Environment.MachineName);
    var distinguishedName = new X500DistinguishedName($"CN=SelfSignedCertificate");
    var request = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256,RSASignaturePadding.Pkcs1);
    request.CertificateExtensions.Add(
        new X509KeyUsageExtension(X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.DigitalSignature , false));
    request.CertificateExtensions.Add(
    new X509EnhancedKeyUsageExtension(
        new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }, false));
    request.CertificateExtensions.Add(sanBuilder.Build());
    var certificate= request.CreateSelfSigned(new DateTimeOffset(DateTime.UtcNow.AddDays(-1)), new DateTimeOffset(DateTime.UtcNow.AddDays(numberOfDaysValid)));
    return certificate.Export(X509ContentType.Pfx, password);
}
private static void EncodeIntegerBigEndian(BinaryWriter stream, byte[] value, bool forceUnsigned = true)
{
    stream.Write((byte)0x02); // INTEGER
    var prefixZeros = 0;
    for (var i = 0; i < value.Length; i++)
    {
        if (value[i] != 0) break;
        prefixZeros++;
    }
    if (value.Length - prefixZeros == 0)
    {
        EncodeLength(stream, 1);
        stream.Write((byte)0);
    }
    else
    {
        if (forceUnsigned && value[prefixZeros] > 0x7f)
        {
            // Add a prefix zero to force unsigned if the MSB is 1
            EncodeLength(stream, value.Length - prefixZeros + 1);
            stream.Write((byte)0);
        }
        else
        {
            EncodeLength(stream, value.Length - prefixZeros);
        }
        for (var i = prefixZeros; i < value.Length; i++)
        {
            stream.Write(value[i]);
        }
    }
}
private static void EncodeLength(BinaryWriter stream, int length)
{
    if (length < 0) throw new ArgumentOutOfRangeException("length", "Length must be non-negative");
    if (length < 0x80)
    {
        // Short form
        stream.Write((byte)length);
    }
    else
    {
        // Long form
        var temp = length;
        var bytesRequired = 0;
        while (temp > 0)
        {
            temp >>= 8;
            bytesRequired++;
        }
        stream.Write((byte)(bytesRequired | 0x80));
        for (var i = bytesRequired - 1; i >= 0; i--)
        {
            stream.Write((byte)(length >> (8 * i) & 0xff));
        }
    }
}
