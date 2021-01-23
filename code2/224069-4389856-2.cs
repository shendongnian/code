    public string GetParentDirectory(string path, int parentCount) {
        if(string.IsNullOrEmpty(path) || parentCount < 1)
            return path;
     
        string parent = System.IO.Path.GetDirectoryName(path);
        
        if(--parentCount > 0)
            return GetParentDirectory(parent, parentCount);
     
        return parent;
    }
