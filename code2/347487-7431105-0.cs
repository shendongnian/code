    public ActionResult Create()
    {
         var model = new MyModel();
         if (Request.IsAjaxRequest())
         {
              return PartialView( "_Partial", model.PartialModel );
         }
         else
         {
              return View( model );
         } 
    }
