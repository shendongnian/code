    public ActionResult Print(myModel myStronglyTypedModel)
        
    {
    	myStronglyTypedModel.SomeStateIWantToKeep += "Print";
    	return View("PrintView");
    }
