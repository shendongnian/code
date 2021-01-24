    public ActionResult Index()
            {   
                 var userGroups = (from g in db.Groups
                                 from u in g.Users
                                 select new UsersGroupViewModel()
                                 {
                                    GroupName = g.groupName,
                                    GroupImageUrl = g.groupImageUrl
                                 }).ToList();
               return View(userGroups);
            }
