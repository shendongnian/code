    var ok = objUser.SaveUser(searchRolesViewModel, System.Web.HttpContext.Current.Session["UserID"].ToString());
    if (ok)
    {
        ModelState.Clear();
        ViewBag.Message = "User added successfully";
    }
    else
    {
        ViewBag.Message = "User not added.";
    }
