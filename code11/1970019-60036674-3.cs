    public ActionResult SaveRecord(Test model)
            {
                try
                {
                    DataComment db = new DataComment();
                
                    db.Test.Add(model);
    
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction("Index");
            }
