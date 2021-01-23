    [HttpPost]
    public ActionResult Edit(UF editedUF)
    {
        if (ModelState.IsValid)
        {
            // Attach the edited UF into the context and change the state to Modified.
            db.UFs.Attach(editedUF);
            db.ObjectStateManager.ChangeObjectState(editedUF, EntityState.Modified);
            // Save changes.
            db.SaveChanges();
            // Call an extension (it's a redirect action to another page, just ignore it).
            return this.ClosePage();
        }
    }
