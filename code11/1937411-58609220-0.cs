    public SetReferences(String[] args)
    {
    	List<AnalyzedAssembly> analyzedAssembly;
    	analyzedAssembly.add(buildAnalyzedAssembly(args[0]);
    	analyzedAssembly.addAll(recursion(args[0])); // Root XML file
    	
    	// Print result by using analyzedAssembly
    }
    
    private List<AnalyzedAssembly> recursion(String xmlFileName) {
    	List<AnalyzedAssembly> analyzedAssembly = new ArrayList<>();
    	XmlDocument doc = new XmlDocument();
    	XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
        ns.AddNamespace("msbld", "http://schemas.microsoft.com/developer/msbuild/2003");
        XmlNodeList nodelist = doc.SelectNodes("//msbld:Reference", ns);
        foreach (XmlNode node in nodelist) {
        	// Create an instance of AnalyzedAssembly and perform recursive call
        	analyzedAssembly.add(node.InnerText); // Use XML file name in node
        	analyzedAssembly.addAll(recursion(node.InnerText));
            
        }
        // Finally return list
        return analyzedAssembly;
    }
    
    private AnalyzedAssembly buildAnalyzedAssembly(String xmlFileName) {
    	var file = new FileInfo(xmlFileName); // Build file with the name given in input
    	AnalyzedAssembly analyzedAssembly = new AnalyzedAssembly
            {
                AssemblyName = file.Name,
                AssemblyFile = file
            };
    	return analyzedAssembly;
    }
