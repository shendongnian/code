        public ActionResult DeleteConfirmed(int id)
      {
        Var a = db. Pages.Where(p => p.PageGroup == id).ToList(); 
         foreach (var item in a) 
            { 
               System.Io.File.Delete(Server.MapPath("/images/" + item.ImageName));
            }
               var d = db.PageGroups.Find(id);
               db.PageGroups.Remove(d);
               db.SaveChanges();
               return RedirectToAction("Index");
          }
