                    //Found this method to filter our child objects instead of using .include()
                    var Results = (from res in
                                       (from u in DataContext.User
                                        where u.Type.ToUpper() != "ADMIN"
                                        && u.StartDate <= DateTime.Now
                                        && (u.EndDate == null || u.EndDate >= DateTime.Now)
                                        select new
                                        {
                                            User = u,
                                            Access = u.Access.Where(a => a.StartDate <= DateTime.Now
                                                      && (a.EndDate == null || a.EndDate >= DateTime.Now))
                                        }
                                        )
                                   select res);
                    //The ToArray is neccesary otherwise the Access is not populated in the Users
                    ReturnValue = Results.ToArray().Select(x => x.User).ToList();
