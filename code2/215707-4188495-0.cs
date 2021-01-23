    public void Main()
    {
    	DirectoryEntry root = new DirectoryEntry("WinNT:");
    	DirectoryServices.DirectoryEntries parent = default(DirectoryServices.DirectoryEntries);
    	parent = root.Children;
    	DirectoryEntries d = parent;
    	foreach (DirectoryEntry complist in parent) {
    		foreach (DirectoryEntry c in complist.Children) {
    			if ((c.Name != "Schema")) {
    				Console.WriteLine(c.Name);
    			}
    		}
    	}
    }
