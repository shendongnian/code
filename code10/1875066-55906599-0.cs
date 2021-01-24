    string filename = "MyFile.txt"; // Make this dynamic from the actual file
    byte[] filedata = System.IO.File.ReadAllBytes(filepath);
    string contentType = MimeMapping.GetMimeMapping(filepath);
    var contentDisposition = new System.Net.Mime.ContentDisposition
    {
        FileName = filename,
        Inline = true
    };
    Response.AppendHeader("Content-Disposition", contentDisposition.ToString());
    return File(filedata, contentType);
