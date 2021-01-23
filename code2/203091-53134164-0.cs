    // no more set ops planned? then returning list is an option
    public static List<T> ExceptWith<T>(HashSet<T> allObjects, Hashset<T> minus)
    {
        //  Set Capacity of list   (allObjects.Count-minus.Count?)
        List<T> retlst = new List<T>(allObjects.Count); 
        foreach( var obj in allObjects) {
            if( minus.Contains(obj)==false)
                retlst.Add(obj);
        }
        return retlst;
    }
    // Special case where quantity of copying will be high
    // more expensive in fact than just adding
    public static HashSet<T> ExceptWith<T>(HashSet<T> allObjects, HashSet<T> minus)
    {
        if( minus.Count > allObjects.Count * 7/8 )
        {
            HashSet<T> retHash = new HashSet<T>(); 
            foreach( var obj in allObjects) {
                if( minus.Contains(obj)==false)
                    retHash.Add(obj);
            }
            return retHash;
        }
        else
        {
            // usual clone and remove
        }
    }
