       public ActionResult AddStudent()
       {
            return View();
       }
       [HttpPost]
       public ActionResult AddStudent(Registration r)
       {
         try
         {
          OQContext db = new OQContext();
           db.Registrations.Add(r);
           db.SaveChanges();
         }
         catch(Exception ex)
         {
         }
         return View();
       }
