    public HttpResponseMessage LoadPdf(int id)
    {
        //get binaryObjecct PDF
        //return binaryObject as HttpResponseMessage
        HttpResponseMessage result = new HttpResponseMessage();
        Stream stream = new MemoryStream(binaryObject.Bytes);//.Bytes is basically byte[] array
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = binaryObject.Name };
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        result.StatusCode = HttpStatusCode.OK;
        return result;
    }
