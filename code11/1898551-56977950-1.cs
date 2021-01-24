	public ActionResult Create()
	{ 
	    return PartialView("_Create"); //DO NOT fill the dropdownlist in this method
	}
	public ActionResult StudentLookup(string query)
	{
	    var students = repository.Students.Select(m => new StudentViewModel
	    {
	        Id = m.Id,
	        Name = m.Name,
	        Surname = m.Surname
	        //FullName = m.Name + " " + m.Surname //Sending "Name" and "Surname" in one parameter    causes "The specified type member 'FullName' is not supported in LINQ to Entities" error!
	    })
	    //if "query" is null, get all records
	    .Where(m => string.IsNullOrEmpty(query) || m.Name.StartsWith(query)) 
	    .OrderBy(m => m.Name);
	    return Json(students, JsonRequestBehavior.AllowGet);
	}
