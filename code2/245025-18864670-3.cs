    //Partial View -
    
    @model User
    
    @Scripts.Render("~/bundles/jqueryval")
    
    @using (Html.BeginForm("Create", "Test1", FormMethod.Post, new { id = "frmNewUser", @class = "form-horizontal" }))
    {
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(true)
    
        @Html.HiddenFor(model => model.UserID)
    <p>@Html.ValidationMessage("errorMsg")</p>
    ...
    
    }
    
    //Do not use Ajax.BeginForm
    
    //Controller -
    
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    user.CreatedDate = DateTime.Now;
                    user.CreatedBy = User.Identity.Name;
        
                    string result = new UserRepository().CreateUser(user);
                    if (result != "")
                    {
                        throw new Exception(result);
                    }
        
                    return Content("succes");
                }
                catch (Exception ex)
                {
                     ModelState.AddModelError("errorMsg", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("errorMsg", "Validation errors");
            }
            return PartialView("_Create", user);
        }
    
