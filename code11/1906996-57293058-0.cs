    [TestMethod]
    public void RegisterSingleton_TwoRegistrationsForTheSameImplementation_ReturnsTheSameInstance()
    {
        var container = new Container();
        container.RegisterSingleton<ShellViewModel>();
        container.RegisterSingleton<IShell, ShellViewModel>();
        var shell1 = container.GetInstance<IShell>();
        var shell2 = container.GetInstance<Shell>();
        Assert.AreSame(shell1, shell2);
    }
