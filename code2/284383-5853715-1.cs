        var condition = "name == Jujyfruits";
        // Parse the condition
        var c = condition.Split(new string[] { "==" }, StringSplitOptions.None);
        var propertyName = c[0].Trim();
        var value = c[1].Trim();
        // Create the lambda
        var arg = Expression.Parameter(typeof(Product), "p");
        var property = typeof(Product).GetProperty(propertyName);
        var comparison = Expression.Equal(
            Expression.MakeMemberAccess(arg, property),
            Expression.Constant(value));
        var lambda = Expression.Lambda<Func<Product, bool>>(comparison, arg).Compile();
        // Test
        var prod1 = new Product() { name = "Test" };
        var prod2 = new Product() { name = "Jujyfruits" };
        Console.WriteLine(lambda(prod1));  // outputs False
        Console.WriteLine(lambda(prod2));  // outputs True
