    //haven't compiled the code.. you can get the basic idea. Note that `System.Object` will always be the base class for every .Net Object
    bool HaveSameBase(Object a, Object b)
    {
        Type t = a.GetType();
        List<Type> aTypeList = new List<Type>();
        while(t.BaseType != System.Object)
            {
            aTypeList.Add(t.BaseType);
            t = t.BaseType;
            }
    
        Type s = b.GetType();
            while(s.BaseType != System.Object)
            {
            if(aTypeList.Any(item => item.Equals(s.BaseType)
                 return true;
            s = s.BaseType;
            }
    
        return false;
    
    }
