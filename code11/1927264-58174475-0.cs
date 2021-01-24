[HttpPost]
public ActionResult MakeComplaint(SecondModel model)
{
    if (ModelState.IsValid)
    {                    
        db.SecondModels.InsertOnSubmit(model)
        return RedirectToAction("Index");
    }
}
and just do something similar for another model:
[HttpPost]
public ActionResult MakeSomethingElse(ThirdModel model)
{
    if (ModelState.IsValid)
    {                    
        db.ThirdModels.InsertOnSubmit(model)
        return RedirectToAction("Index");
    }
}
