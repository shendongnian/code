    public ActionResult Save(FormCollection form)
    {
    var empType = Type.GetType("Example.Models.Employee");
    var emp = Activator.CreateInstance(empType);
 
    var binder = Binders.GetBinder(empType);
 
      var bindingContext = new ModelBindingContext()
      {
        ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => emp, empType),
        ModelState = ModelState,
        ValueProvider = form
      };      
 
      binder.BindModel(ControllerContext, bindingContext);
 
      if (ModelState.IsValid)
      {
       _empRepo.Save(emp);
 
        return RedirectToAction("Index");
      }
 
    return View();
    }
