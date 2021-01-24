        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FileDetails fileDetails)
        {
              if (ModelState.IsValid)
              {
                string uploadedfilename = 
                     Path.GetFileName(fileDetails.filebeforetourupload.FileName);
                if (!string.IsNullOrEmpty(uploadedfilename))
                {
                    db.FileUpload.Add(fileDetails);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
              }
            return View(fileDetails);
        }
