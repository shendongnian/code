    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(TblPersons model, int parentId)
    {
        if(ModelState.IsValid)
        {
            db.UpdatePerson(model, parentId, currentUserId);
        }
    
        return RedirectToAction("Index");
    }
