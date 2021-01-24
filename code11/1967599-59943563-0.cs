     [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int? Id, int[] selectedIDs)
            {
                if(Id>0)
                {
                    objemployee.DeleteEmployee(Id);
    
                }
                else
                {
                    foreach(int item in selectedIDs)
                    {
                        objemployee.DeleteEmployee(item);
                    }
                }
                return RedirectToAction("Index");
            } 
