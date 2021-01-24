 public ActionResult AssignRoles()
        {
            ViewBag.Users = new SelectList(db.Users, "Id", "UserName");
            ViewBag.Roles = new SelectList(db.Roles, "Name", "Name"); // Here I was Passing the Id insted Of Role Name.
            return View();
        }
        [HttpPost]
        public ActionResult AssignRoles(string Users,string Roles)
        {
            usersManager.AddToRole(Users, Roles);
            ViewBag.Users = new SelectList(db.Users, "Id", "UserName");
            ViewBag.Roles = new SelectList(db.Roles, "Name", "Name");
            return View();
        }
