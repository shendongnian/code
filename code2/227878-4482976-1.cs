    [TestMethod]
    public static void SomeMethod_Test()
    {
        // some mock initialization
        var bl = new BusinessLogic(new FakeMailSender());
        bl.SomeMethod();
        // checks
    }
