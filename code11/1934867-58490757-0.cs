    private IEnumerable<string> GetMaxVersions(IEnumerable<FileVersionDetail> files) 
    {
    		//1. Group the list by base/floor version numbers.
    		var groupedByBaseVersion = files.Select(f => f.VersionNumber).GroupBy(f => f.Split('.')[0]);
    
    		//2. Find the max in each group.
    		return groupedByBaseVersion.Select(g => g.ToArray().Max());
    }
