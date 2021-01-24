    public class PostBodyMessage
    {
     public List<IFormFile> files {get; set;}
     public string destinationPath {get; set;}
     public bool createPath {get; set;}
     public bool overwriteFile {get; set;}
    }
    [HttpPost("UploadFile/{multipart}", Name = "UploadFile")]
    [RequestSizeLimit(40000000)] // Max body size (upload file size)
    public async Task<ActionResult<bool>> UploadFile(PostBodyMessage message)
    {
        // server side code here
    }
