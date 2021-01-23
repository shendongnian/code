    static bool ArePermutations<T>(IList<T> list1, IList<T> list2)
    {
       if(list1.Count != list2.Count)
             return false;
    
       var l1 = list1.ToLookup(t => t);
       var l2 = list2.ToLookup(t => t);
      
       return l1.Count == l2.Count 
           && l1.All(group => l2.Contains(group.Key) && l2[group.Key].Count() == group.Count()); 
    }
