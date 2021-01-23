    [HttpPost]
         public ActionResult Index(object obj)   
         {    
    	     UserModel test = new UserModel();
    	     TryUpdateModel(test);	
    	     ViewBag.Test = test.InputName;     
         	     return View();     
          } 
