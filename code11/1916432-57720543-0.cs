    public ViewResult List() => 
      View(repository.Users.First(dbuser => 
    new Models.User(){
        UserName = dbuser.Username,
        FirstName = dbuser.FirstName,
        LastName = dbuser.FamilyName
    });
