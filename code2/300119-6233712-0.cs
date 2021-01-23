        [HttpPost]
        public ActionResult UploadImage()
        {
            string galleryId = Request.Form["GalleryId"];
            string title = Request.Form["ImageTitleField"];
            string description = Request.Form["ImageDescriptionField"];
            HttpPostedFileBase imageUpload = Request.Files["ImageUploadField"];
            return RedirectToAction("Edit", new { new Guid(galleryId) });
        }
