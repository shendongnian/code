    public JsonResult GetPersonDetails(int Id){
        var person = db.Person.Where(m => m.Id == Id); //this should be accessed from the db
        return Json(person);
    }
    
