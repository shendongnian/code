    //I assume a bool variable UserIsValid which you set after validating the user
    if (UserIsValid)
    {
        //If user was redirected back to login page then go back to requested page
        if (Request.QueryString["ReturnUrl"] != null)
        {
            FormsAuthentication.RedirectFromLoginPage("User_name", false);
        }
        else
        {
            //Set an Auth cookie
            FormsAuthentication.SetAuthCookie("User_name", false);
            //And then redirect to main page
            Response.Redirect("mainPage.aspx");
        }
    }    
    else
    {
        //User was not valid, do processing
    }
       
