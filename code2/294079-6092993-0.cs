    Public void IsValidUser()
    {
       if(User.Identity.Name!=string.empty)
         Response.Redirect("~login.aspx");
       else
       {
          if(!User.Identity.IsAuthenticated)
            Response.Redirect("~login.aspx");
       }
    }
