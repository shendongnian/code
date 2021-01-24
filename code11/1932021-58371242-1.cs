    private List<string> GetDiffOfSubfolders(string source, string dest)
    {
    	DirectoryInfo sourceDir = new DirectoryInfo(source);
    
    	DirectoryInfo destinationDir = new DirectoryInfo(dest);
    
    	var subDirsSrc = sourceDir.GetDirectories();
    	var subDirsDesc = destinationDir.GetDirectories();
    	var subDirsDescFolderNames = subDirsDesc.Select(x => x.Name).ToList();
    
    	List<string> notMatchedSubFolders = new List<string>();
    
    	foreach (var folder in subDirsSrc)
    	{
    		if (subDirsDescFolderNames.Contains(folder.Name))
    		{
    			DirectoryInfo sourceSubDir = new DirectoryInfo(folder.FullName);
    			var list1 = sourceSubDir.GetFiles("*", SearchOption.AllDirectories).Select(x => Path.GetFileName(x.FullName));
    
    			string destinationSubFolderName = subDirsDesc.FirstOrDefault(x => x.Name == folder.Name).FullName;
    			DirectoryInfo destSubDir = new DirectoryInfo(destinationSubFolderName);
    			var list2 = destSubDir.GetFiles("*", SearchOption.AllDirectories).Select(x => Path.GetFileName(x.FullName));
    
    			var diff = list1.Except(list2);
    
    			if (diff.Any())
    			{
    				notMatchedSubFolders.Add(folder.FullName);
    			}
    		}
    		else
    		{
    			notMatchedSubFolders.Add(folder.FullName);
    		}
    	}
    
    	return notMatchedSubFolders;
    }
