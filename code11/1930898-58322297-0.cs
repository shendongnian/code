    string defaultOrder = "DepartmentId DESC";
    
    var people = DbContext.People
        .Select(p => new PersonViewModel{
            Name = p.Name,
            ManagerId = p.ManagerId,
            DepartmentId = p.DepartmentId
        })
        .OrderBy(p => (paging.Sorting.ToLower().Contains("managerid") && p.ManagerId == null) ? defaultOrder : paging.Sorting)
