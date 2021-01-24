    namespace DC.Controllers
    {
        public class CommentController : Controller
        {
            public ActionResult SaveRecord(View model)
            {
                try
                {
                    DataComment db = new DataComment();
                    Test view= new Test(); //This is change
                    view.Id = model.Id;
                    view.Name = model.Name;
    
                    db.Test.Add(view);
    
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction("Index");
            }
        }
    }
