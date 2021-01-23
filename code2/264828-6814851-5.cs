    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection) {
                    //dbcontext   //dbname            //id field
    var languages = globalizationdb.lang.Where(x => x.lang_id == id).Single();
          
       //dbcontext 
       globalizationdb.SubmitChanges();
       return RedirectToAction("Index");
    }
