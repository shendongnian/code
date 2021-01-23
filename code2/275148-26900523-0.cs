    public static bool IsParent(string fullPath, string base)
    {
    	var fullPathSegments = SegmentizePath(fullPath);
    	var baseSegments = SegmentizePath(base);
    	var index = 0;
    	while (fullPathSegments.Count>index && baseSegments.Count>index && 
    		fullPathSegments[index].Trim().ToLower() == baseSegments[index].Trim().ToLower())
    		index++;
    	return index==baseSegments.Count-1;
    }
    public static IList<string> SegmentizePath(string path)
    {
    	var segments = new List<string>();
    	var remaining = new DirectoryInfo(path);
    	while (null != remaining)
    	{
    		segments.Add(remaining.Name);
    		remaining = remaining.Parent;
    	}
    	segments.Reverse();
    	return segments;
    }
