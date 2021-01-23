        var types =
            System.Reflection.Assembly.GetExecutingAssembly()
                .GetReferencedAssemblies()
                .SelectMany(name => Assembly.Load(name).GetTypes())
                .Union(AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()));
