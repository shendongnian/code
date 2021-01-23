    public ActionResult MyAction()
    {
    
       var model = new SettingsViewModel{
              ChangePasswordModel = new ChangePasswordModel()
           }
       return View(model);
    
    }
