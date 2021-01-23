            [AjaxOnly]
            [HttpPost]
            public ActionResult UploadImageAction(HttpPostedFileBase UploadImage)
            {
               string path = Server.MapPath("~") + "Files\\UploadImages\\" + UploadImage.FileName;
               System.Drawing.Image img = new Bitmap(UploadImage.InputStream);    
               img.Save(path);
               return View();
            }
