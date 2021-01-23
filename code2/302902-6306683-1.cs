    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Person(TblPersons model, int parentId)
    {
        if(ModelState.IsValid)
        {
            db.UpdatePerson(model, parentId, currentUserId);
        }
    
        return RedirectToAction("Person");
    }
