    var controllerToTest = new HomeController();
    var context = new MockHttpContextBase(controllerToTest);
   
    // do stuff that you want to test e.g. something goes into session
    Assert.IsTrue(context.HttpContext.Session.Count > 0); 
