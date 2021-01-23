    //to sign-in:
    FormsAuthentication.SignIn("username", createPersistentLogin);
    //to sign-out:
    FormsAuthentication.SignOut();
    //user data access:
    Page.User.IsInRole("requiredRole");
    Page.User.Identity.IsAuthenticated;
    Page.User.Name;
    
