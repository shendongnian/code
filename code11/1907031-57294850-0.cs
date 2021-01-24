    void Main()
    {
    	string fileName = @"e:\Temp\GamePatches.xml";
    	
    	XDocument manifest = XDocument.Load(fileName);
    	string version = manifest.Root.Attribute("version").Value;
    
    	List<ManifestModel> manifestModel = new List<ManifestModel>();
    
    	foreach (XElement e in manifest.Descendants("file"))
    	{
    		manifestModel.Add(new ManifestModel() { Version = version
    				, Resource = (string)e.Attribute("resource").Value 
    				, Size = (string)e.Attribute("size").Value 
    				, Checksum = (string)e.Attribute("checksum").Value }
    				);
    	}
    }
    
    // Define other methods and classes here
    public class ManifestModel
    {
    	public string Version { get; set; }
    	public string Resource { get; set; }
    	public string Size { get; set; }
    	public string Checksum { get; set; }
    }
