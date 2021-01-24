    using (MyConnectionString _context = new MyConnectionString())
    {
        var list = (from d in _context.Departments
                    select new
                    {
                        d.DepartmentId,
                        d.DepartmentName
                    }).ToList();
        SelectList dList = new SelectList(list, "DepartmentId", "DepartmentName");
        ViewBag.DepartmentId = dList;
    }
