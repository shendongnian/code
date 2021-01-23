    public string[] SplitString(string s)
    {
      Regex regex = new Regex(@"^[A!]+$");
      if (!regex.IsMatch(s))
      {
          throw new ArgumentException("Wrong input string!");
      } 
      return Regex.Split(s, @"(A!?)").Where(x => !string.IsNullOrEmpty(x)).ToArray();
    }
