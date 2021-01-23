      public Index(int? page)
            {
    
    int pageSize=10;    
    var List= Repo.GetAllMembers();    
    var paginatedList = List.Skip((page ?? 0) * pageSize).Take(pageSize).ToList();
    return View(paginatedList);    
    }
 
