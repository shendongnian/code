        [HttpGet]
        public IActionResult Edit(int? id)
        { 
           //Give this a name other than view model for example BookViewModel
           ViewModel model = new ViewModel();
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.Books.Include(b => b.Category)
                        .Include(b => b.Author)
                        .SingleOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            model.Book = book;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookViewModel model, int? id)
        {
            if (id == null || id != model.Book.BookId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var dbModel = _db.Books.Include(b => b.Category).Where(b => b.BookId == id).FirstOrDefault();
            var files = HttpContext.Request.Form.Files;
            if (files.Any())
            {
                var RootDirectory = _hostingEnvironment.WebRootPath;
                var extension = Path.GetExtension(files[0].FileName);
                var filePath = Path.Combine(DataContext.ImageDirectory, model.Book.BookId + extension);
                using (var fileStream = new FileStream(Path.Combine(RootDirectory, filePath), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }
                dbModel.ImagePath = @"/" + filePath;
            }
            dbModel.AuthorId = model.Book.AuthorId;
            dbModel.CategoryId = model.Book.CategoryId;
            dbModel.Discount = model.Book.Discount;
            dbModel.Price = model.Book.Price;
            dbModel.Stock = model.Book.Stock;
            dbModel.Title = model.Book.Title;
            await _db.Books.UpdateAsync(dbModel);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            return View(model);
          
        }
