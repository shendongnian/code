        [HttpPost]
        public ActionResult UploadImage(HttpPostedFile uploadFile)
        {
            if (uploadFile.ContentLength > 0)
            {
                var imgService = new ImgUrImageService();
                byte[] fileBytes = new byte[uploadFile.ContentLength];
                uploadFile.InputStream.Read(fileBytes, 0, fileBytes.Length);
                uploadFile.InputStream.Close();
                string fileContent = Convert.ToBase64String(fileBytes);
                var response = imgService.Upload(fileContent);
            }
            return View();
        }
