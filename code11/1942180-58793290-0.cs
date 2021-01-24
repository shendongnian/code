C #
[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(... IFormFile Photo)
        {
            ObjectViewModel model = new ObjectViewModel ();
            
            if (ModelState.IsValid)
            {
                string uidFileName = null;
                if (... && Photo != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uidFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Photo.FileName);
                    string filePath = Path.Combine(uploadFolder, uidFileName);
                    Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    ObjectABC abc = new ObjectABC()
                    {
                        ...
                        Photo = uidFileName
                    };
                    _context.Add(abc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }           
           ...
            ...
            model.Photo = Photo;
            return View(model);
        }
