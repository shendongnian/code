    [HttpPost]
    public ActionResult Edit(Models.MathClass mathClassModel)
    {
        //get current entry from db (db is context)
        var item = db.Entry<Models.MathClass>(mathClassModel);
        //change item state to modified
        item.State = System.Data.Entity.EntityState.Modified;
        //load existing items for ManyToMany collection
        item.Collection(i => i.Students).Load();
        //clear Student items          
        mathClassModel.Students.Clear();
        //add Toner items
        foreach (var studentId in mathClassModel.SelectedStudents)
        {
            var student = db.Student.Find(int.Parse(studentId));
            mathClassModel.Students.Add(student);
        }                
        if (ModelState.IsValid)
        {
           db.SaveChanges();
           return RedirectToAction("Index");
        }
        return View(mathClassModel);
    }
