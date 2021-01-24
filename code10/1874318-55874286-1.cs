    public HttpResponseMessage LoadPdf(int id)
    {
        //get PDF in myByteArray
        //return PDF bytes as HttpResponseMessage
        HttpResponseMessage result = new HttpResponseMessage();
        Stream stream = new MemoryStream(myByteArray);
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "my-doc.pdf" };
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        result.StatusCode = HttpStatusCode.OK;
        return result;
    }
