    public ActionResult ServiceCenterPost(ServiceCenterPost model)
    {
         foreach (var file in model.FileUpload)
         {
              if (file != null && file.ContentLength > 0)
              {
                 byte[] fileBytes = new byte[file.ContentLength];
                 file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                 string thumbpath = _fileStorageService.GetPath(fileName);
                _fileStorageService.SaveFile(thumbpath, fileBytes);
             }
         }
    }
