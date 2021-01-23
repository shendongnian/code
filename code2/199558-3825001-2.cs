    public string ToPrettyCommas<T>(
      List<T> source,
      Func<T, string> stringSelector
    )
    {
      int count = source.Count;
    
      Func<string, int> prefixSelector = x => 
        x == 0 ? "" :
        x == count - 1 ? " and " :
        ", ";
    
      StringBuilder sb = new StringBuilder();
    
      for(int i = 0; i < count; i++)
      {
        sb.Append(prefixSelector(i));
        sb.Append(stringSelector(source[i]));
      }
    
      string result = sb.ToString();
      return result;
    }
    
    
