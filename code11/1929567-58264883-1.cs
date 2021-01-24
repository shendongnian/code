    public bool Check(string s)
    {
        return                           // return true if and only if 
          s != null &&                   // s is not null and
          s.Length == 8 &&               // s has Length of 8 and
          s.Count(Char.IsUpper) == 1 &&  // s has exactly 1 Upper case letter and
          s.Any(Char.IsDigit);           // s has at least one digit 
    }
