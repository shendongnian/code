       [HttpGet]
                public FileStreamResult DownloadPngFileFromDataBase(string id)
                {
                    var _fileUpload = _db.ImageFileUpload.SingleOrDefault(aa => aa.fileid == id);         
                    // _fileUpload.FileContent column type is byte
                    MemoryStream ms = new MemoryStream(_fileUpload.FileContent);
                    return new FileStreamResult(ms, "image/png");
                }
