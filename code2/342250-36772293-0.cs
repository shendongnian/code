     public ActionResult EditTextProperty([Bind(Include = "Id,ProductID,Name,Description,Value,CreateDate,ModifyDate,IsHaveNectar")] PVM_TextProperty TextProperty)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(TextProperty).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(TextProperty);
            }
