    string Commaize (IEnumerable<string> sequence)
    {
        IList<string> list=sequence as IList<string>;
        if(list==null)
          list=sequence.ToList();
        StringBuilder sb=new StringBuilder();
        for(int i=0;i<list.Count-1;i++)
        {
          sb.Append(list[i]);
          sb.Append(", ");
        }
        sb.Append("and ");
        sb.Append(list[list.Count-1]);
        return sb.ToString();
    }
