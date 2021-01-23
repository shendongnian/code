    [HttpPost]
    public ActionResult GetPet()
    {
    Cat catObj;
    Dog dogObg;
    if (TryUpdateModel(catObj))
    		return Json(catObj.purr());
    else
    {
    	ModelState.Clear();
    	if (TryUpdateModel(dogObg))
    		return Json(dogObj.bark());
    	else
    	{
    		ModelState.Clear();
    		ModelState.AddModelError("InvalidInput", "The given input does not match with any of the accepted JSON types");
    		return new HttpBadRequestResult(ModelState);
    	}
    }
    
    }
