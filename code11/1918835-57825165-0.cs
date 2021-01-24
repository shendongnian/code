    public ActionResult SomeActionMethod() {
      try{
          //perform action related to button call maybe saving in database and so on
          return Json(new {Message="Value Saved Successfully", Status="200"});
       }
       catch(Exception ex)
       {
          return Json(new {Message=ex.Message, Status="400"}); //here ex.Message shows the error message
       }
    }
