    ViewBag.AuthorsList = new SelectList(db.Authors.Select(x =>
                                                           new 
                                                           {
                                                            Id = x.Id,
                                                            FirstName = x.FirstName
                                                           }).ToList(), 
                                          "Id", 
                                          "FirstName");
        
