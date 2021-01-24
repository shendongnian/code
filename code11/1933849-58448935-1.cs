    List<string> MergedList = new List<string>();
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
