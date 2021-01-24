    var people = DbContext.People
                              .Select(p => new PersonViewModel{
                              Name = p.Name,
                              ManagerId = p.ManagerId,
                              DepartmentId = p.DepartmentId
                              })
                              .OrderBy(o => o.GetType()
                              .GetProperty(paging.Sorting)
                              .GetValue(o, null))
 
