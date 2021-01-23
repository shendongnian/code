    static double BinaryStringToDouble(string s)
    {
      if(string.IsNullOrEmpty(s))
        throw new ArgumentNullException("s");
      double d = 0;
      foreach(var c in s)
      {
        d *= 2;
        if(c == '1')
          d += 1;
        else if(c != '0')
          throw new FormatException();
      }
      return d;
    }
