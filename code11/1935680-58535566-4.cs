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
public static bool FileUpload(HttpPostedFileBase file)
{
    if (file != null && file.ContentLength > 0)
    {
        var path = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"), Path.GetFileName(file.FileName));
        file.SaveAs(path);
        var hash = CreateHash(path);
        if (!FileAlreadyExists(hash))
        {
            var fileMetaData = new Google.Apis.Drive.v3.Data.File();
            fileMetaData.Name = Path.GetFileName(file.FileName);
            fileMetaData.MimeType = MimeMapping.GetMimeMapping(path);
            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var service = GetService();
                request = service.Files.Create(fileMetaData, stream, fileMetaData.MimeType);
                request.Fields = "id";
                request.Upload();
            }
            return true;
        }
        return false;
    }
    return false;
}
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
    fileListRequest.Fields = "*";
    var files = fileListRequest.Execute().Files;
    foreach (var file in files)
    {
        if(file.Md5Checksum.Equals(hash))
        {
            return true;
        }
    }
    return false;
}
