    public ActionResult SignUp(string username, string password)
    {
        var user = new User();    // Your model object
        user.Username = username; //...
        _repository.Save(user);
        return Redirect(...); 
    }
