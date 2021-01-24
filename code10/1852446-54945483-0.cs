    [Route("api/getdeptemployee/{Id}")]
    [HttpGet]
    public IActionResult GetDepartmentEmp(int Id)
    {
        var item = (from o in db.Employee
                    join a in db.Department on o.DepartmentId equals a.Id
                    where a.Id == Id
                    select new
                    {
                        Id = o.Id,
                        LastName = o.LastName.Trim(),
                        AddedBy = o.LastName.Trim() + " " + o.FirstName.Trim()
                    }).OrderBy(s => s.LastName.ToLower()).ToList();
        return Json(item);
    }
