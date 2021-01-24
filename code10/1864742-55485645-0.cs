        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignAdmin(AssignRolesModel model)
        {
            try
            {
                if(model.lstUsers == null)
                {
                    TempData["Error"] = "There are no Users to Assign Roles";
                    model.lstUsers = UserList();
                    model.lstAdmins = AdminList();
                    return View(model);
                }
                var selectedUsersCount = (from user in model.lstUsers
                                          where user.SelectedUsers == true
                                          select user).Count();
                if(selectedUsersCount == 0)
                {
                    TempData["Error"] = "You have not Selected any User to Assign Roles";
                    model.lstAdmins = AdminList();
                    model.lstUsers = UserList();
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    List<UserModel> users = new List<UserModel>();
                    ApplicationUser au;
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    model.CreatedBy = 1;
                    
                    foreach(var u in model.lstUsers)
                    {
                        if(u.SelectedUsers == true)
                        {
                            users.Add(u);
                        }
                    }
                    foreach(var u in users)
                    {
                        au = context.Users.Where(x => x.Id.Equals(u.UserId,
                            StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                        manager.AddToRole(au.Id, "Admin");
                    }
                    TempData["Success"] = "Roles Assigned Successfully";
                    return RedirectToAction("AssignAdmin");
                }
            }
            catch (Exception)
            {
                throw;
            }           
            return View();
        }
