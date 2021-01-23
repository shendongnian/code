    void Main()
    {
    	// this is your base scenario
    	IEnumerable<FileInfo> fileInfos = new List<FileInfo>{new FileInfo("a_1"), new FileInfo("c"), new FileInfo("a"), new FileInfo("b"), new FileInfo("b_1000")};
    	
    	// now use the new class
    	IEnumerable<ComparableFileInfo> cFileInfos = fileInfos.Select(x => new ComparableFileInfo(x));
    	
    	var nameGroups = cFileInfos.GroupBy(x => x.BaseName).Select(group => new {group.Key, MaxFile = group.Max()});
    	
    	foreach (var g in nameGroups.OrderBy(x => x.Key))
    	{
    		Console.WriteLine(g.MaxFile.OrigFileInfo.FullName);
    	}	
    }
    
    class ComparableFileInfo : IComparable{
    
    	public FileInfo OrigFileInfo; // omit getters and setters for brevity
    	public int FileVersion; 
    	public string BaseName;
    	
    	public ComparableFileInfo(FileInfo fileInfo){
    		this.OrigFileInfo = fileInfo;
    		int splitIdx = fileInfo.Name.LastIndexOf("_");
    		this.BaseName = splitIdx < 0 ? fileInfo.Name : fileInfo.Name.Substring(0, splitIdx);
    		string version = fileInfo.Name.Substring(splitIdx+1, fileInfo.Name.Length - splitIdx -1);
    		int versionCast;
    		this.FileVersion = Int32.TryParse(version, out versionCast) ? versionCast : 0;
    	}
    	
    	public int CompareTo(object obj)
    	{
    		if (obj is ComparableFileInfo)
    		{
    			ComparableFileInfo f2 = (ComparableFileInfo)obj;
    			return this.FileVersion.CompareTo(f2.FileVersion);
    		}
    		else
    			throw new ArgumentException("Object is not a ComparableFileInfo");
    	}	
    }
