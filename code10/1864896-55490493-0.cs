    public ActionResult Multidata(string sortOrder, string searchString, string currentFilter, int? page, string searchBy, string startdate = null, string enddate = null)
    {
        var mymodel = new PersonViewModel();
        ViewBag.CurrentSort = sortOrder;
        ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        mymodel.pers = db.People.ToList();
        mymodel.emp = db.Employees.ToList();
        mymodel.history = db.EmployeeDepartmentHistories.ToList();
        /* ... */
        if (searchBy == "Title")
        {
            return View(mymodel.Where(x => x.emp.JobTitle == searchString || searchString == null).ToList());
        }
        else
        {
            return View(mymodel.Where(x => x.pers.FirstName.StartsWith(searchString) || x.pers.LastName.StartsWith(searchString) || searchString == null).ToList());
        }
    }
