     if (e.CommandName == "Delete" &&
         Request.Form[e.CommandArgument.ToString()] != null &&
         Page.User.Identity.IsAuthenticated)
     {
         //delete things.
     }
