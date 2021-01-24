    [HttpPost]
            public JsonResult Details(int? id)
            {
    
                HomeModel model = new HomeModel();
                var book = db.Books.Where(b => b.Id == id).Include(b => b.Author).SingleOrDefault();
                if (book == null)
                {
                    HttpNotFound();
                }
    
                book.DisplayNumber++;
                db.SaveChanges();
                model.bookDetails = book;
                return Json(model);
            }
