    public void Build(DbModelBuilder builder) 
    {
      // Stuff
      
      var param = Expression.Parameter(typeof(DbModelBuilder));
      foreach (var type in types)
      {
        var method = Expression.Call(
          Expression.Constant(this),      // Call to self.
          "BuildInternal",                // The method to call.
          new[] { type },                 // The generic arguments.
          param);                        // The parameters.
          
        Expression.Lambda(method, param).Compile().DynamicInvoke(builder);
      }
    }
