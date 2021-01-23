    _container.Kernel.ComponentModelCreated += model =>
    {
        IEnumerable<PropertySet> nonInjectableProperties = model.Properties
            .Where(set => set.Property.Name == "ActiveItem").ToList();
    
        foreach (PropertySet nonInjectableProperty in nonInjectableProperties)
        {
            model.Properties.Remove(nonInjectableProperty);
        }
    }
