    if (user.GetRole(model.UserName).Equals("Admin"))
    {
        ViewBag.Role = "Admin";
    }
    else{
        ViewBag.Role = "";
    }
