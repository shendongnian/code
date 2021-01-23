    foreach (ManagementObject adapter in searcher.Get())
    {
       string adapterName = adapter.Properties
                                   .Cast<PropertyData>()
                                   .Single(p => p.Name == "Name")
                                   .Value;
    }
