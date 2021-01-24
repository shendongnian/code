        [HttpPost]
        public IHttpActionResult AcceptUserInfoAndFiles()
        {
            User userInfo = new User();
            var httpContext = HttpContext.Current;
            NameValueCollection nvc = HttpContext.Current.Request.Form;
            // Fill User data ....
            userInfo.UserId=Convert.ToInt32(nvc["UserId"]);
            userInfo.FirstName = nvc["FirstName"];
            List<Document> documents = new List<Document>();
            // Check for any uploaded file  
            if (httpContext.Request.Files.Count > 0)
            {
                //Loop through uploaded files                  
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
                    if (httpPostedFile != null)
                    {
                        // Get data in byte array
                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(httpPostedFile.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(httpPostedFile.ContentLength);
                        }
                        documents.Add(new Document
                        {
                            DocumentId = 1, //Generate your document id
                            Name = httpPostedFile.FileName, // Remove extension if you want to store only name
                            Extension = System.IO.Path.GetExtension(httpPostedFile.FileName), // Get file extension
                            Data = fileData
                        });
                    }
                }
            }
            userInfo.Documents = documents;
            return Ok();
        }
