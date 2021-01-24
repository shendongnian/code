    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ParamNoRekeningSumberDana model)
    {
        if (ModelState.IsValid)
        {
            ParamNoRekeningSumberDana newrecord = new 
            ParamNoRekeningSumberDana();
            newrecord.ID = Guid.NewGuid();
            newrecord.AccountNo = model.AccountNo;
            newrecord.CreatedBy = Session["UserName"].ToString();
            db.ParamNoRekeningSumberDanas.Add(newrecord);
            db.SaveChanges();
            TempData["SuccessCreate"] = "Saved successfully";
            return RedirectToAction("Index");
       }
       else
       {
             return View(model);
       }
