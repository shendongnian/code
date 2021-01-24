    [HttpGet, Route("api/files/{FileAttachmentID}")]
        public IHttpActionResult FileAttachment_Get(string FileAttachmentID)
        {
            using (TSTDBContext dbContext = new TSTDBContext())
            {
                Guid FileAttachmentGUID = new Guid(FileAttachmentID);
                var entity = dbContext.FileAttachment_Get(FileAttachmentGUID).SingleOrDefault();
                if (entity != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        var result = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(entity.Content)//this is your varbinary value
                        };
                        result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                        {
                            FileName = entity.Name
                        };
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        var response = ResponseMessage(result);
                        return response;
                    }
                }
                else
                {
                    return NotFound();
                }
            }
