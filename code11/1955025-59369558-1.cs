    this.Map = assembly.GetTypes()
        .Where( t => typeof(IProcessor).IsAssignableFrom( t ))
        .ToDictionary
        (
            t => t.Name, 
            t => new Func<IProcessor>( () => Activator.CreateInstance(t) as IProcessor );
        );
