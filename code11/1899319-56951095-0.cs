byte[] GetMD5Checksum(List<int> list)
{
    var binaryFormatter = new BinaryFormatter();
    using(var stream = new MemoryStream())
    using (var md5 = MD5.Create())
    {
        binaryFormatter.Serialize(memoryStream, list);
        return md5.ComputeHash(stream);
    }
}
