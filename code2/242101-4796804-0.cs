    public new virtual bool Add(TObject item)
    {
        // Must add parent first, since it may be used in the hash code
        // InnerList is a HashSet<T>
    
        if (InnerList.Any(existing=>item.GetHashCode()==existing.GetHashCode())) {
            return(false);
        } else {
            if (InnerList.Add(item))
            {
                return(true);
            } else {
                return(false);
            }
        }
    }
