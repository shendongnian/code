    container.Configure(r =>
    {
      foreach (var assembly in
          AppDomain.CurrentDomain.GetAssemblies())
      {
        r.Scan(s =>
        {
          s.Assembly(assembly);
          s.AddAllTypesOf<MyBaseType>();
        });
      }
    });
