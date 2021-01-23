    [HttpGet]
    public ActionResult CreatePerson()
    {
         return View( new Person() );
    }
    [HttpPost]
    public ActionResult CreatePerson( PersonViewModel person )
    {
        var person = ...create and persist a Person entity based on the view model....
        return Redirect("details", new { id = person.id } );
    }
