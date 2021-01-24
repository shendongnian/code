      public ActionResult Delete(int? id)
            {
                ***code goes here****
    
               var lansing = db.LansingMileages.Find(id);
                viewModel.Records = new[]
                {
                    lansing
                };
    
                db.LansingMileages.Remove(lansing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }  
