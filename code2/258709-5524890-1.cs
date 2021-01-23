     class IndexActionHandler : DefaultActionHandler
     {
       public IndexActionHandler(HttpListenerRequest request)
         : base(request)
       {
       }
       
       public override ActionResult Execute()
       {
         var result = new HtmlResult();
         result.AppendLine("<html>");
         result.AppendLine("<body>");
         result.AppendLine("<h1>Upload an image</h1>");
         result.AppendLine("<form action='/Upload' enctype='multipart/form-data' method='post'>");
         result.AppendLine ("<input name='Image' type='file'/><br/>");
         result.AppendLine("<input name='Upload' type='submit' text='Upload'/>");
         result.AppendLine("</form>");
         result.AppendLine("</body>");
         result.AppendLine("</html>");
         return result;
       }
     }
     
     class UploadActionHandler : DefaultActionHandler
     {
       public UploadActionHandler(HttpListenerRequest request)
         : base(request)
       {
       }
     
       public override ActionResult Execute()
       {
         string errorMessage = null;
         var file = FormData.GetFile("Image");
         if (file == null 
           || file.FileData == null 
           || file.FileData.Length == 0 
           || string.IsNullOrEmpty(file.FileName))
           errorMessage = "No image uploaded";
         
         if (errorMessage == null)
           ProcessFile(file);
           
         var result = new HtmlResult();
         result.AppendLine("<html>");
         result.AppendLine("<body>");
         if (errorMessage == null)
           result.AppendLine("<h1>File uploaded successfully</h1>");
         else
         {
           result.AppendLine("<h1>Error</h1>");
           result.AppendLine("<h2>" + errorMessage + "</h2>");
         }
         result.AppendLine("</body>");
         result.AppendLine("</html>");
         return result;
       }
       
       void ProcessFile(MultiPartStreamFileValue postedFile)
       {
         string fileName = "Where to save the file";
         using (var fileStream = 
           new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
         {
           fileStream.Write(postedFile.FileData, 0, postedFile.FileData.Length);
         }
       }
     }
