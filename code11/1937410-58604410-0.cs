    class Program
    {
    	static void Main(string[] args)
    	{
    		new SetReferences(args);
    
    		Console.WriteLine("\nPress any key to exit.");
    		Console.ReadKey();
    	}
    	
    	private SetReferences(string[] args)
    	{
    		XmlDocument doc = new XmlDocument();
    		doc.Load(args[0]);
    		XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
    		ns.AddNamespace("msbld", "http://schemas.microsoft.com/developer/msbuild/2003");
    		XmlNodeList nodelist = doc.SelectNodes("//msbld:Reference", ns);
    		HandleNodes(nodelist);
    	}
    	
    	private HandleNodes(XmlNodeList[] nodes)
    	{
    		foreach (XmlNode node in nodelist)
    		{
    
    			var file = new FileInfo(node.InnerText);
    			AnalyzedAssembly analyzedAssembly = new AnalyzedAssembly
    			{
    				AssemblyName = file.Name,
    				AssemblyFile = file
    			};
    
    
    			Console.WriteLine(analyzedAssembly.AssemblyName);
    			Console.WriteLine(analyzedAssembly.AssemblyFile);
    			
    			// Get a new nodelist from the inner XML
    			// and call HandleNodes on this new nodelist here.
    		}
    	}
    }
    
    public class AnalyzedAssembly
    {
    	public string AssemblyName { get; set; }
    	public FileInfo AssemblyFile { get; set; }        
    	public List<AnalyzedAssembly> ChildDepencies { get; } = new List<AnalyzedAssembly>();
    
    }
