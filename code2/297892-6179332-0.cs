        if (HttpContext.Current.User.IsInRole("RoleName"))
        {
            return true;
        }
        else
        {
            return false;
        }
