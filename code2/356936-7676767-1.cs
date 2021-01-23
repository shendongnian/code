    [TestMethod]
    public void TestThatUserInfoIsValidatedAndSaved()
    {
        var user = new User{Name = "Bob"};
        UserService.SaveUser(user);
    
        //Check that data access got called to see if Bob exists
        //Check that validation got called
        //Check that data access got called to save bob
    }
    
    [TestMethod]
    public void ShouldSaveNewUser()
    {
        var user = new User{Name = "Bob"};
        UserService.SaveUser(user);
    
        //Check that bob was saved
    }
