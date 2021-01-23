    Assembly resourceAssembly = Assembly.LoadFrom(resourceFile.FullName);
    string[] manifests = resourceAssembly.GetManifestResourceNames();
    using (ResourceReader reader = new ResourceReader(resourceAssembly.GetManifestResourceStream(manifests[0])))
    {
        IDictionaryEnumerator dict = reader.GetEnumerator();
        while (dict.MoveNext())
        {
            string key = dict.Key as string;
            object val = dict.Value;
        }
    }
