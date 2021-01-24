{
    public async Task<HttpResponseMessage> GetDicomImage(string FolderName)
    {
        var content = new MultipartContent();
        var filePathInfo = Directory.GetFiles(FolderName);
        var files = new List<FileData>();
        foreach (var dcm in filePathInfo)
        {
            var fileData = new FileData { Content = File.ReadAllBytes(dcm), Name = Path.GetFileName(dcm) };
            files.Add(fileData);
        }
        content.files = files.ToArray();
        httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
        httpResponseMessage.Content = JsonConvert.SerializeObject(content);
    }
}
public class MultipartContent
{
    public FileData[] files;
}
public class FileData
{
    public byte[] Content;
    public string Name;
}
It is not needed to return stream however. It is enough to return `byte[]` and file name (to make it possible to save file later)
Then you will need to read the response content on client and to deserialize it back to MultipartContent instance 
PS Seems that you are trying to send files from the host to the client.
This is not safe since client defines path to be used to get files from. It looks like a security risk even if hosting process do not have permission to read system files. 
Probably you can define certain codes for folders to be mapped on the host side.
Like `documents - ./documents` `images - ./images`. `GetDicomImage` should be modified to accept `documents` `images` codes and to map the code to the physical paths.
It will prevent client from requesting the "c:\\" folder (that will not be processed but can be used to DDOS the hosting service.)
