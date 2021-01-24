    db.EmployeeAreas.Select(e => new YourViewModel{
      ParentName = e.AreaName,
      ChildNames = e.EmployeeNames.Select(en => new List<string>{
        EmployeeName = en.Name
      }).ToList();
    }).ToList();
