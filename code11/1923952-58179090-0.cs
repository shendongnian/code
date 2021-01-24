    [HttpGet]
    [Route("profile_image")]
    public async Task<IHttpActionResult> GetProfileImageData()
    {
        var profileImage = Db.Candidate.Include(x => x.ProfileImage).AsNoTracking().Single().ProfileImage;
    
        using (var file = await _fileService.DownloadFileAsync(profileImage.FileGuid))
        {
            var memory = new MemoryStream();
            await file.CopyToAsync(memory);
    
            // Create response message
            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(memory.ToArray())
            };
    
            //Otroligt att man ska behöva kladda med detta, men "filename" i Content Disposition accepterar enbart us-ascii strängar i vissa webbläsare
            var encoder = Encoding.GetEncoding("us-ascii", new EncoderReplacementFallback(string.Empty), new DecoderExceptionFallback());
            string asciiFileName = encoder.GetString(encoder.GetBytes(profileImage.FileName));
    
            // Set content headers
            message.Content.Headers.ContentLength = memory.Length;
            message.Content.Headers.ContentType = new MediaTypeHeaderValue(profileImage.ContentType ?? "application/octet-stream");
            message.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = asciiFileName,
                Size = file.Length
            };
    
            return new ResponseMessageResult(message);
        }
    }
