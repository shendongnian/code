    string role = string.empty;
    if (Validate_User(loginModel, out role))
    {
        if (role == "Admin")
        {
            return View("AdminView");
        }
        else
        {
            return View("UserView");
        }
    }
    else
    {
        //handle failed login
    }
