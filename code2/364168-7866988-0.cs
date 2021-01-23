    public ActionResult DeleteConfirmed(int id) 
    {             
        A objA = db.As.Find(id); 
        objA.Bs.Clear();
        db.As.Remove(objA); 
        db.SaveChanges(); 
        return RedirectToAction("Index"); 
    } 
