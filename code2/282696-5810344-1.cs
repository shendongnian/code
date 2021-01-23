     [AcceptVerbs(HttpVerbs.Post)]
     public ActionResult Create(FormCollection collection)
     {
         try
         {
             string create = Request.Form["create"];
             string cancel = Request.Form["cancel"];
             return RedirectToAction("Index");
         }
         catch
         {
             return View();
         }
     }
