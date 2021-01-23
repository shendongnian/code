    Assembly assembly = Assembly.LoadFrom(assemblyName);
    string[] names = assembly.GetManifestResourceNames();
    ResourceSet set = new ResourceSet(assembly.GetManifestResourceStream(names[0]));
    IDictionaryEnumerator id = set.GetEnumerator();
    while(id.MoveNext())
            Console.WriteLine("\n[{0}] \t{1}", id.Key, id.Value); 
