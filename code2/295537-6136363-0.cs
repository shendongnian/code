    var propValue = prop.GetValue(bo, null); // this (in case the `prop` is a virtual `ICollection<Component>`) lazy loads all components, returning them not always in the same order (due to paralelism on sql server?))
    if (prop.PropertyType.IsGenericType)
    {
        ...
        if (prop.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
        {
            ...        
        }
        else if (innerType.IsSubclassOfOrEquivalentTo(typeof(Component)) && propValue != null)
        {
            // order the list of components in memory into a new variable
            var listOfComponents = ((IEnumerable) propValue).Cast<Component>().OrderBy(c => c.ComponentId);            
                        
            dynamic componentsHash = propValue; // I had to use dynamic, because sometimes the propValue was an List<...>, sometimes a HashSet<...>, sometimes a ...
            componentsHash.Clear(); // empty the collection retrieved by EF
            int componentCount = listOfComponents.Count;
            for (var i = 0; i < componentCount; i++)
            {
                var component = listOfComponents[i];
                componentsHash.Add(component); // re-add components to the collection
                ...
            }
            // at this point the collection object contains ordered dynamic proxy objects (attached EF objects)
        }
        else
        {
            ...
        }
    }
    ...
