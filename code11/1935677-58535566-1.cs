if (file.Equals(path))
{
    return false;
}
As you commented, Md5Checksum is the property you need to check against.
if (file.Md5Checksum.Equals(path))
{
    return false;
}
Also, your `HashGenerator` method contains this line:
return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "null").ToLower();
I think `null` should be removed, so it's like this:
return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
The end result (with some refactoring) would be:
public static string CreateHash(string path)
{
    using (var md5 = MD5.Create())
    {
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
        }
    }
}
public static bool FileAlreadyExists(string hash)
{
    var service = GetService();
    var fileListRequest = service.Files.List();
    var files = fileListRequest.Execute().Files;
    foreach (var file in files)
    {
        return !file.Md5Checksum.Equals(hash);
    }
    return true;
}
