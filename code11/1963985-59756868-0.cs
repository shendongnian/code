    private List<String> DirSearch(string rootDir)
    {
        List<String> files = new List<String>();
        try
        {
            foreach (string f in Directory.GetFiles(rootDir))
            {
    			FileInfo fi = new FileInfo(f);
    			if(fi.Extension==".dwg"){
    				string parent = System.IO.Directory.GetParent(rootDir).FullName;
    				files.Add(parent);
    			
    			}
            }
            foreach (string d in Directory.GetDirectories(rootDir))
            {
                files.AddRange(DirSearch(d));
            }
        }
        catch
        {
            
        }
    
        return files;
    }
