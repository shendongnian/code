    var asm = Assembly.GetEntryAssembly();
    string resName = asm.GetName().Name + ".g.resources";
    using (var stream = asm.GetManifestResourceStream(resName))
    using (var reader = new System.Resources.ResourceReader(stream))
    {
        var paths = from entry in reader.Cast<DictionaryEntry>()
                    where ((string)entry.Key).Contains("sub-folder-name")
                    select entry.Key;
        if (paths.Any())
        {
            foreach (string path in paths)
            {
                Uri uri = new Uri(String.Format(
                          "pack://application:,,,/{0};component{1}", asm.GetName(), path)
                          , UriKind.Absolute);
                //use the uri for the rest
            }
        }
    }
