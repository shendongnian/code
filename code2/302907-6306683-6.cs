    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Tbl_Persons model, int parentId)
    {
        if(ModelState.IsValid)
        {
            db.UpdatePerson(model, parentId, currentUserId);
        }
    
        return RedirectToAction("Index");
    }
