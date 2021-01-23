    using(var context = new FooBarEntities())
    {
      context.ContextOptions.LazyLoadingEnabled = false;
      Foo foo = context.Foo.Where(x => x.Id == myId).Single();
      ...
      if(!foo.Bars.IsLoaded)
      {
          foo.Bars.Load();
      }
      //do something with foo.Bars here
    }
