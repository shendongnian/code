public ActionResult Create(Models.User user)
{
    var roleToAssign = rolesRepository.GetById(2);
    Models.Role roleConverted = new Models.Role() { Id = roleToAssign.Id , Name = roleToAssign.Name };
    user.RegisterOn = DateTime.Now;
    user.Role = roleConverted;
    user.RoleId = roleConverted.Id;
    if (ModelState.IsValid)
    {
        if (userServices.ExistingEmailAddress(user.Email))
        {
            ModelState.AddModelError("Email", "This email address can not be used.");
        }
        if (userServices.ExistingUsername(user.Username))
        {
            ModelState.AddModelError("Email", "This username can not be used.");
        }
        if(!userServices.ExistingUsername(user.Username) && !userServices.ExistingEmailAddress(user.Email))
        {
            var dbModel = new Domain.Entities.User();
            TryUpdateModel(dbModel);
            // try this here
            dbModel.RoleId = roleConverted.Id;
            
            // you might also need
            dbModel.RegisterOn = DateTime.Now;
            
            userServices.AddUser(dbModel);
            return RedirectToAction("Index");
        }
        return View(user);
    }
    return View(user);
}
