    var query  = from d in departments
                 orderby d.department_name 
                 select new { id = d.department_id, name = d.department_name };
    var serviceDepartments = query.AsEnuemrable()
                                  .Select(x => new ServiceDepartment
                                          {
                                              DepartmentName = x.name,
                                              DepartmentID = x.id
                                          })
                                  .ToArray();
