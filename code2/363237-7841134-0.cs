    [HttpPost]
    public ActionResult UpdateItem (Employee model){
    //   save model here
    
    return RedirectToAction("Index", "Home"); //something like this
    }
