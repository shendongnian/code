    var listOfImageResources = new StringBuilder();
    var asm = Assembly.GetExecutingAssembly();
    var mrn = asm.GetManifestResourceNames();
    foreach (var resource in mrn)
    {
        var rm = new ResourceManager(resource.Replace(".resources", ""), asm);
        try
        {
            var NOT_USED = rm.GetStream("app.xaml"); // without getting a stream, next statement doesn't work - bug?
            var rs = rm.GetResourceSet(Thread.CurrentThread.CurrentUICulture, false, true);
            var enumerator = rs.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().StartsWith("images/"))
                {
                    listOfImageResources.AppendLine(enumerator.Key.ToString());
                }
            }
        }
        catch (MissingManifestResourceException)
        {
            // Ignore any other embedded resources (they won't contain app.xaml)
        }
    }
    MessageBox.Show(listOfImageResources.ToString());
