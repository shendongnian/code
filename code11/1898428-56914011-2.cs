    public ActionResult AddingEmp()
    {
        SelectList depts = new SelectList(db.Departaments, "Depart_Name", "Depart_Name");
        ViewBag.Depts = depts;
        return View();
    }
    [HttpPost]
    public ActionResult AddingEmp(Employee addingEmp, FormCollection form)
    {
        addingEmp.departament = form["Depart_Name"].ToString();       
        db.Employees.Add(addingEmp);
        db.SaveChanges();
        return View();
    }
