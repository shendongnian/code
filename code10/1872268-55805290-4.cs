        var serviceAssembly = Assembly.GetAssembly(typeof(CategoryService));
        foreach (var type in serviceAssembly.GetTypes())
        {
            if (type.Name.Contains("Service") && !type.IsInterface && !type.IsGenericType)
            {
                Type interfaceImplement = type.GetInterfaces().SingleOrDefault(t => t.IsGenericType == false);
                if (interfaceImplement != null)
                {
                    System.Diagnostics.Debug.WriteLine($"{type.Name} is inherited by {interfaceImplement.Name}");
                    services.AddTransient(interfaceImplement, type);
                }
            }
        }
