    string txt = "";
    int count = 0;
    StringBuilder bldr = new StringBuilder();
    foreach(char c in txt) 
    {
      if (c == '\')
      {
        count++;
        if (count < 3) 
    	{
          bldr.Append(c);
        }
      }
      else 
      {
        count = 0;
        bldr.Append(c);
      }
    }
    string result = bldr.ToString();
