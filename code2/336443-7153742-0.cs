    public static bool match(string p, string s)
    {
      while (true)
      {
        // normal code
        ...
        // tail call handling
        // instead of return match(x, y)
        var t1 = x; // need to use temps for evaluation of x
        var t2 = y; // same here
        p = t1;
        s = t2;
        continue; 
      }
    }
