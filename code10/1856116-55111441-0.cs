    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Ida,description,UserId,Idc,titre,image")] Article article, HttpPostedFileBase image)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Idc = new SelectList(db.Categories, "Id", "libelle", article.Idc);
            return View(article); 
        }
    
        using (var db = new IdentityDBEntities())
        {
            var existingArticle = db.Articles.Single(x => x.ArticleId == article.ArticleId);
            if (existingArticle.RowVersion != article.RowVersion) // Or compare LastModifiedDateTime etc.
            {
                // Set a validation state to tell the user that the article had changed since they started editing. Perhaps merge values across, but send the article back.
                return View(existingArticle);
            }
    
            if (image != null)
                existingArticle.image = image.FileName;
    
            existingArticle.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId(); // can this be updated?
            db.SaveChanges(); 
        }
        return RedirectToAction("Index");
    }
