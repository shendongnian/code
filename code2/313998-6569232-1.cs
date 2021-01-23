        [HttpPost]
        [ValidateAntiForgeryToken]
        [DemandAuthorization(RoleNames.AdminUser, AlwaysAllowLocalRequests = true)]
        public ActionResult AllUsers(int UserID)
        {
            try
            {
               //save to db or whatever...
                return RedirectToAction("Index", "Users");
            }
            catch (RulesException ex)
            {
                ex.CopyTo(ModelState); //custom validation copied to model state
            }
            var _users= _service.GetUsers();
            return View("AllUsers", new UsersViewModel
            {
                UserID = UserID,
                AvailableUsers = _users
            });
    
        }
