    [HttpGet("path")]
    [Produces("image/jpeg", "image/webp", "text/plain")]
    public async Task<ActionResult<FileContentResult>> Get(/*parameters*/)
    {
        if(/*invalid parameters*/)
        {
           throw new HttpResponseException(/* invalid parameters message */, HttpStatusCode.BadRequest)
        }
        Byte[] image = GetImage();
        return File(image, "image/jpeg");
    }
