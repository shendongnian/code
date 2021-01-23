    public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
    {
          if ( f1 == null || f2 == null)
          {
              return false;
          }
          
          return (f1.Name == f2.Name && f1.Directory.Name == f2.Directory.Name && 
                 f1.Length == f2.Length);
    }
    public int GetHashCode(System.IO.FileInfo fi)
    {
        unchecked
        {
            int hash = 17;    
            hash = hash * 23 + fi.Name.GetHashCode();
            hash = hash * 23 + fi.Directory.Name.GetHashCode();
            hash = hash * 23 + fi.Length.GetHashCode();
    
            return hash;
        }
    }
