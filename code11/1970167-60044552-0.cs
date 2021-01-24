    var result = new HttpResponseMessage(HttpStatusCode.OK)
    {
    	Content = new ByteArrayContent(renderedBytes)
    };
    result.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType); //"application/pdf"
    var input = $"inline; filename={fileNameExtension}"; //where fileNameExtension something with file name and extension for e.g., myfilename.txt
    ContentDispositionHeaderValue contentDisposition;
    if (ContentDispositionHeaderValue.TryParse(input, out contentDisposition))
    {
    	result.Content.Headers.ContentDisposition = contentDisposition;
    }
    
    return this.ResponseMessage(result);
