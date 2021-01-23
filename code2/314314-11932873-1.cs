    var model = AutoMap.AssemblyOf<MyDb>()
                    .Where(t => t.Namespace.StartsWith("MyDb.Tables"))
                    .Conventions.AddFromAssemblyOf<MyDb>();
    Conventions.Setup(x =>  {   
      x.AddFromAssemblyOf<MyDb>();   
      x.Add(AutoImport.Always());  }); // AutoImport.Never()
