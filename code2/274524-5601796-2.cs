    [TestMethod]
    public void Windsor_Can_Resolve_HomeController_Dependencies()
    {
        // Setup
        WindsorContainer container = new WindsorContainer();
        container.Install(FromAssembly.Containing<HomeController>());
        // Act
        HomeController controller = container.Resolve<HomeController>();
    }
