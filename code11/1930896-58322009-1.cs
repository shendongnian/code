    var people = DbContext.People
                          .Select(p => new PersonViewModel{
                          Name = p.Name,
                          ManagerId = p.ManagerId,
                          DepartmentId = p.DepartmentId
                          })
                          .OrderBy(paging.Sorting)
