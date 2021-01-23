    private static UnmanagedMemoryStream GetResourceStream(string resName)
    {
    	var assembly = Assembly.GetExecutingAssembly();
    	var strResources = assembly.GetName().Name + ".g.resources";
    	var rStream = assembly.GetManifestResourceStream(strResources);
    	var resourceReader = new ResourceReader(rStream);
    	var items = resourceReader.OfType<DictionaryEntry>();
    	var stream = items.First(x => (x.Key as string) == resName.ToLower()).Value;
    	return (UnmanagedMemoryStream)stream;
    }
    
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
    	string resName = "Test.txt";
    	var file = GetResourceStream(resName);
    	using (var reader = new StreamReader(file))
    	{
    		var line = reader.ReadLine();
    		MessageBox.Show(line);
    	}
    }
