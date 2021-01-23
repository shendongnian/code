    MemoryStream.GetBuffer() can return extra empty bytes at the end of the byte[], but you can fix that by using MemoryStream.ToArray() instead. However, I found this alternative to work perfectly for all file types:
    
    using (var binaryReader = new BinaryReader(file.InputStream))
    {
        byte[] array = binaryReader.ReadBytes(file.ContentLength);
    }
    Here's my full code:
    
    Document Class:
    
    public class Document
    {
        public int? DocumentID { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public int? ContentLength { get; set; }
    
        public Document()
        {
            DocumentID = 0;
            FileName = "New File";
            Data = new byte[] { };
            ContentType = "";
            ContentLength = 0;
        }
    }
    File Download:
    
    [HttpGet]
    public ActionResult GetDocument(int? documentID)
    {
        // Get document from database
        var doc = dataLayer.GetDocument(documentID);
    
        // Convert to ContentDisposition
        var cd = new System.Net.Mime.ContentDisposition
        {
            FileName = doc.FileName, 
    
            // Prompt the user for downloading; set to true if you want 
            // the browser to try to show the file 'inline' (display in-browser
            // without prompting to download file).  Set to false if you 
            // want to always prompt them to download the file.
            Inline = true, 
        };
        Response.AppendHeader("Content-Disposition", cd.ToString());
    
        // View document
        return File(doc.Data, doc.ContentType);
    }
    File Upload:
    
    [HttpPost]
    public ActionResult GetDocument(HttpPostedFileBase file)
    {
        // Verify that the user selected a file
        if (file != null && file.ContentLength > 0)
        {
            // Get file info
            var fileName = Path.GetFileName(file.FileName);
            var contentLength = file.ContentLength;
            var contentType = file.ContentType;
    
            // Get file data
            byte[] data = new byte[] { };
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                data = binaryReader.ReadBytes(file.ContentLength);
            }
    
            // Save to database
            Document doc = new Document()
            {
                FileName = fileName,
                Data = data,
                ContentType = contentType,
                ContentLength = contentLength,
            };
            dataLayer.SaveDocument(doc);
    
            // Show success ...
            return RedirectToAction("Index");
        }
        else
        {
            // Show error ...
            return View("Foo");
        }
    }
    View (snippet):
    
    @using (Html.BeginForm("GetDocument", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        <input type="file" name="file" />
        <input type="submit" value="Upload File" />
    }
