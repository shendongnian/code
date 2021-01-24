    public ActionResult Edit()
    {
     //var newUser = UserManager.FindById(User.Identity.GetUserId());
     City city = db.Cities.FirstOrDefault();
     newUser.Cities = new List<City>() { city };
     newUser.SurName = "TestName";
     //var result =  UserManager.Update(newUser);
     db.Entry(newUser).State = EntityState.Modified;
     db.SaveChanges();
     ....
    }
