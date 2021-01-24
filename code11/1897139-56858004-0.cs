    public class FileStreamWithLengthResult : ActionResult
    {
        private Stream stream;
        private string mimeType;
        private string fileName;
        private long contentLength;
        public FileStreamWithLengthResult(Stream stream,string mimeType,string fileName)
        {
            this.stream = stream;
            this.mimeType = mimeType;
            this.fileName = fileName;
            this.contentLength = stream.Length;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.BufferOutput = false;
            response.Headers.Add("Content-Type", mimeType);
            response.Headers.Add("Content-Length", contentLength.ToString());
            response.Headers.Add("Content-Disposition", "attachment; filename=" + fileName);
            stream.CopyTo(response.OutputStream);
        }
    }
