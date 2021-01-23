    public int GetHashCode(System.IO.FileInfo fi)
    {
        unchecked
        {
            int hash = 17;    
            hash = hash * 23 + fi.Name.GetHashCode();
            hash = hash * 23 + fi.Length.GetHashCode();
    
            return hash;
        }
    }
