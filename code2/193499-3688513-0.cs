    public class FileUriResult : ActionResult
    {
      private string _contentType;
      private string _fileUri;
      private long _fileLength;
      public FileUriResult(string contentType, string fileUri, long fileLength)
      {
        _contentType = contentType;
        _fileUri = fileUri;
        _fileLength = fileLength;
      }
      public override void ExecuteResult(ControllerContext context)
      {
        if (context == null)
        {
          throw new ArgumentNullException("context");
        }
        HttpResponseBase response = context.HttpContext.Response;
        response.ContentType = _contentType;
        response.AddHeader("Content-Disposition", "attachment; filename=" + _fileUri);
        response.AddHeader("Content-Length", _fileLength.ToString(); 
      }
    }
   
