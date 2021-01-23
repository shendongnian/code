    int[] items = new[] { 1, 5, 7, 14 }; 
    var selecteditems = (from u in _entities.UserInfo 
                            where u.UserId == userid && items.Contains(u.TypeID)
                            select new UserClass {
                                                FirstName = u.FirstName, 
                                                LastName = u.LastName, 
                                                Email = ul.Email
                                        }).ToList();
