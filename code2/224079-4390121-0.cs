    List<string> myList = GetNumberStrings();
    
    myList.Select(s=>s.Split('.')).ToArray().
       .Sort((a,b)=>RecursiveCompare(a,b))
       .Select(a=>a.Aggregate(new StringBuilder(),
          (s,sb)=>sb.Append(s).Append(".")).Remove(sb.Length-1, 1).ToString())
       .ToList();
    
    ...
    
    public int RecursiveCompare(string[] a, string[] b)
    {
        return RecursiveCompare(a,b,0)
    }
    
    public int RecursiveCompare(string[] a, string[] b, int index)
    {
        return index == a.Length || index == b.Length 
            ? 0 
            : a[index] < b[index] 
                ? -1 
                : a[index] > b[index] 
                    ? 1 
                    : RecursiveCompare(a,b, index++);
    }
