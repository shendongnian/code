    static double BinaryStringToDouble(string s)
    {
      if(string.IsNullOrEmpty(s))
        throw new ArgumentNullException("s");
      double sign = 1;
      int index = 1;
      if(s[0] == '-')
        sign = -1;
      else if(s[0] != '+')
        index = 0;
      double d = 0;
      for(int i = index; i < s.Length; i++)
      {
        char c = s[i];
        d *= 2;
        if(c == '1')
          d += 1;
        else if(c != '0')
          throw new FormatException();
      }
      return sign * d;
    }
