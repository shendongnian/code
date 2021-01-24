     [HttpPost, ValidateHeaderAntiForgeryToken]
        public JsonResult Add_Customer()
        {
            var errMsg = string.Empty;
            byte[] tmpImage;
            try
            {
                //Customer Image Processing
                var file = Request.Files.Get("file");
                if (file != null && file.ContentLength > 0)
                {
                    //Image Saving to Folder
                    UploadHelper.UploadFile(file);
                    //Image Saving to Database
                    tmpImage = new byte[file.ContentLength];
                    file.InputStream.Read(tmpImage, 0, file.ContentLength);
                    CustomerModel model = new CustomerModel
                    {
                  
                        Signature = tmpImage
                    };
                    _setupRepo.CreateSignatory(model);
                    return Json(new { error = false, result = $"Customer was successfully created" }, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
                return Json(new { error = true, result = errMsg }, JsonRequestBehavior.AllowGet);
            }
        }
