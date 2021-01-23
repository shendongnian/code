    var model = AutoMap.AssemblyOf<MyDb>()
                    .Where(t => t.Namespace.StartsWith("MyDb.Tables"))
                    .Conventions.AddFromAssemblyOf<MyDb>();
    Conventions.Setup(x =>  {   
      x.AddFromAssemblyOf<Program>();   
      x.Add(AutoImport.Always());  }); // AutoImport.Never()
