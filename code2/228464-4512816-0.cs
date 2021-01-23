    IManagerFactory managerFactory = new ManagerFactory();
    using (ICategoryManager categoryManager = managerFactory.GetCategoryManager())
    {
        Category categoryA = new Category();
        categoryA.Id = "TEST1";
        categoryA.Name = "Test 1";
        categoryA.Descn = "Hello world!";
    
        categoryManager.Save(categoryA);
        categoryManager.Session.CommitChanges();
    }
