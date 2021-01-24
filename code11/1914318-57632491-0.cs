    [HttpPost]
    [Route("api/uploadPDF")]
    public async Task<IHttpActionResult> UploadFile()
    {
        try
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }
            var fileProvider = await Request.Content.ReadAsMultipartAsync();
            var pdfStream = await fileProvider.Contents.First().ReadAsStreamAsync();
            //do something with the pdf stream
            return Ok(new { Posted = true });                
        }
        catch (Exception ex)
        {
            ex.LogException();
            return InternalServerError(ex);
        }
    }
