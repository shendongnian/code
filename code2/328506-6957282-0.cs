    static void NewAssemblyLoaded(object sender, AssemblyLoadEventArgs args)
    {
        Assembly anAss = args.LoadedAssembly;
        foreach (Type t in Assembly.GetTypes())
        {
            if (!t.IsInterface && typeof(IAnimal).IsAssignableFrom(t))
                animalsList.Add(t);
        }
    }
