    using ( var ctx = new ...)
    {
      var user = new User();
      var product = new Product();
      user.Products.Add(product);
      ctx.Users.AddObject(user);
      ctx.SaveChanges();
    }
