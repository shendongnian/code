    class FileInfoComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            // if x and y are the same instance, or both are null, they are equal
            if (object.ReferenceEquals(x,y))
            {
                return true;
            }
            // if one is null, they are not equal
            if (x==null || y == null)
            {
                return false;
            }
            // compare Length and Name
            return x.Length == y.Length && 
                x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase);
        }
    
        public int GetHashCode(FileInfo obj)
        {
            return obj.Name.GetHashCode() ^ obj.Length.GetHashCode();
        }
    }
