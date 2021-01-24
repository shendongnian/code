    [HttpPost]
    public ActionResult AddAdmin(AdminViewModel model)
    {           
       if(ModelState.IsValid) 
       {
          List<Roles> list = new List<Roles>(col.Roles.ToList());
          model.Roles = col.Roles.ToList().Select(x => new SelectListItem()
                {
                    Value = x.RoleName,
                    Text = "Choose a role...",
    
                }).ToList();
    
         var admin = new Admin()
         {
            FirstName = model.FirstName,
            LastName = model.LastName,
            MemberEmail = model.MemberEmail,
            //// If RoleName column is an type of VarChar then you are doing wrong here.
            // RoleName = list.Select(x => x.RoleName).ToString();
    
            //// try static string of role.
            RoleName = "Admin"
            or
            RoleName = list.FirstOrDefault(x => x.RoleName == model.[RoleNameFieldFromModel])?.RoleName;
         };
    
         DBContext.Admin.Add(admin);
         DBContext.SaveChanges();
       }
      return View(model);
    }
