    string Commaize (IEnumerable<string> sequence)
    {
        IList<string> list=sequence as IList<string>;
        if(list==null)
          list=sequence.ToList();
        if(list.Count==0)
          return "";
        else if(list.Count==1)
          return list.First();
        else
          return String.Join(", ", list.Take(list.Count-1).ToArray()) + " and " + list.Last();
    }
