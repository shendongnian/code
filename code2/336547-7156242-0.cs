    [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            // my project need single file upload so i get the first file
            // also you can write foreach statement to get all files
            HttpPostedFileBase postedFile = Request.Files[0];
            Image image = new Image();
            if (TryUpdateModel(image))
            {
                fRepository.AddImage(image);
                fRepository.Save();
                // Try to save file
                if (postedFile.ContentLength > 0)
                {
                    string savePath = Path.Combine(Server.MapPath("~/Content/OtelImages/"), image.ImageID.ToString() +
                                                       Path.GetExtension(postedFile.FileName));
                    postedFile.SaveAs(savePath);
                        
                    // Path for dbase
                    image.Path = Path.Combine("Content/OtelImages/", image.ImageID.ToString() +
                                                       Path.GetExtension(postedFile.FileName));
                }
