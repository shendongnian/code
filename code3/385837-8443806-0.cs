    [Test]
    public void AddSessionStarShouldSaveFormToSession()
    {
        TestControllerBuilder builder = new TestControllerBuilder();
        StarsController controller = new StarsController();
        builder.InitializeController(controller);
        //note that this is assigned before the controller action. This simulates the server  filling out the form data from the request
        builder.Form["NewStarName"] = "alpha c";
        //this assumes that AddSessionStar takes the form data and adds it to the session
        controller.AddSessionStar();
        Assert.AreEqual("alpha c", controller.HttpContext.Session["NewStarName"]);
    }
