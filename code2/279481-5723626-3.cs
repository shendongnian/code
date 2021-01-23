    FacebookApp facebook = new FacebookApp ();
    if (facebook.IsAuthenticated) {
            string userName = facebook.UserId.ToString();
            if (UsersRepository.ByUserName(userName ) == null) {
                // Create a User using the Facebook name, email, etc data
            }            
            FormsAuthentication.SetAuthCookie (userName , true);
    }
