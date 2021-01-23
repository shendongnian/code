    string ReplaceEscapeSequences(string s)
    {
      Contract.Requires(s != null);
      Contract.Ensures(Contract.Result<string>() != null);
      StringBuilder sb = new StringBuilder();
      for(int i = 0; i < s.Length; i++)
      {
        if(s[i] == '\\')
        {
          i++;
          if(i == s.Length)
            throw new ArgumentException("Escape sequence starting at end of string", s);
          switch(s[i])
          {
            case '\\':
              sb.Append('\\');
              break;
            case 't':
              sb.Append('\t');
              break;
            ...
          }
        }
        else sb.Append(s[i]);
      }
      return sb.ToString();
    }
