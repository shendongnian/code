    List<string> MergedList;
    foreach(List<string> ls in ListsToMerge)
    {
        foreach(string s in ls)
        {
           if(!MergedList.Contains(s))
           {
               MergedList.Add(s)
           }
        }
    }
