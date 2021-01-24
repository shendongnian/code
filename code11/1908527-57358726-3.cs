    [HttpGet]
            public FileStreamResult DownloadFileFromDataBase(string id)
            {
                var _fileUpload = _db.FileUpload.SingleOrDefault(aa => aa.fileid == id);         // _fileUpload.FileContent type is byte
                MemoryStream ms = new MemoryStream(_fileUpload.FileContent);
                return new FileStreamResult(ms, "application/pdf");
            }
