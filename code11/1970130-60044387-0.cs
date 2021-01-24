     [HttpPut, Route("api/student/{studentId}/classes/{classId}")]
        public async Task<string> Put(int studentId, int classId)
        {
            if (HttpContext.Current.Request.Files.Count == 0)
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    ReasonPhrase = "Files are required",
                    StatusCode = HttpStatusCode.BadRequest
                });
            foreach (string file in HttpContext.Current.Request.Files)
            {
                var postedFile = HttpContext.Current.Request.Files[file];
                if (postedFile.ContentType != "application/octet-stream")
                {
                    throw new System.Web.Http.HttpResponseException(new HttpResponseMessage()
                    {
                        ReasonPhrase = "Wrong content type",
                        StatusCode = HttpStatusCode.BadRequest
                    });
                }
            }
            return "OK";
        }
