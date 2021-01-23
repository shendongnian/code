    string Commaize (IEnumerable<string> sequence)
    {
        IList<string> list=sequence as IList<string>;
        if(list==null)
          list=sequence.ToList();
        return String.Join(", ",list.Take(list.Count-1))+"and "+list.Last();
    }
