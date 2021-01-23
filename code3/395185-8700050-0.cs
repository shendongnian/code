    [TestMethod]
    public void GetAll_with_Unity()
    {
      var container = new UnityContainer();
      container.RegisterType<ICustomerRepository, CustomerRepository>();
      container.RegisterType<ICustomerBiz, CustomerBizImp>();
      container.RegisterType<ICustomerService, CustomerService>();
      var svc = container.Resolve<ICustomerService>();
      var all = svc.GetAll();
      Assert.AreEqual(1, all.Count());
    }
